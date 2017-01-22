using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsTools : MonoBehaviour {
    public RectTransform canvas;
    public LayoutElement creditsLayout;
    public RectTransform creditsScroll;
    public Text creditsText;
    public float scrollDelay = 0.1f;
    public float scrollStep = 1f;
    public float typedDelay = 0.1f;
    public float floatIntervals = 60;

    protected bool running = true;

    protected IEnumerator BlankPause(float pauseTime)
    {
        creditsText.text = "";
        yield return new WaitForSeconds(pauseTime);
    }

    /// <summary>
    /// Fade text in and out on the screen
    /// </summary>
    /// <param name="lines">String array of lines to display.</param>
    /// <param name="fadeTime">Duration of fade in or out in seconds as float.</param>
    /// <param name="pauseTime">Duration of the pause once fade in is completed before fading out, in seconds as float/</param>
    /// <returns>To allow yielding for it to finish.</returns>
    protected IEnumerator StartFade(string[] lines, float fadeTime, float pauseTime)
    {
        string textFade = "";
        for (int i = 0; i < lines.Length; i++)
        {
            textFade += lines[i] + "\n";
        }

        TextHide();
        creditsText.text = textFade;
        yield return StartCoroutine(DisplayFade(0.0f, 1.0f, floatIntervals, fadeTime));
        yield return new WaitForSeconds(pauseTime);
        yield return StartCoroutine(DisplayFade(1.0f, 0.0f, floatIntervals, fadeTime));
        creditsText.text = "";
        TextShow();
    }

    void TextShow()
    {
        creditsText.color = new Color(creditsText.color.r, creditsText.color.g, creditsText.color.b, 1.0f);
    }

    void TextHide()
    {
        creditsText.color = new Color(creditsText.color.r, creditsText.color.g, creditsText.color.b, 0.0f);
    }

    IEnumerator DisplayFade(float start, float end, float intervals, float time)
    {
        float r = creditsText.color.r;
        float g = creditsText.color.g;
        float b = creditsText.color.b;

        float delay = time / intervals;

        for (int i = 0; i < intervals; i++)
        {
            yield return new WaitForSeconds(delay);
            float a = start + ((end - start) * (i / intervals));
            creditsText.color = new Color(r, g, b, a);
        }
    }

    /// <summary>
    /// Move the credits text off screen and begin scrolling it upwards.
    /// </summary>
    /// <param name="lines">String array with the lines to scroll up the screen.</param>
    /// <returns>To allow yielding for it to finish.</returns>
    protected IEnumerator StartScroll(string[] lines)
    {
        // NOTE: Theoretically this should get the dimensions of the game canvas.
        // In practice it doesn't seem to work correctly
        print(canvas.rect.height);
        print(creditsScroll.rect.height);

        float midHeight = canvas.rect.height / 2;
        float startHeight = -midHeight - 50;
        // TODO: calculate the height the scrolling text should disappear
        // Needs actual canvas dimension
        // Also may be worth looking into whether unity can calculate whether this is on screen or not.
        float disappearHeight = 1250;

        Vector2 original = creditsScroll.anchoredPosition;
        creditsScroll.anchoredPosition = new Vector2(0, startHeight);

        string textScroll = "";
        for (int i=0; i<lines.Length; i++)
        {
            textScroll += lines[i] + "\n";
        }

        creditsText.text = textScroll;

        yield return StartCoroutine(DisplayScroll(scrollDelay, disappearHeight));

        creditsText.text = "";
        creditsScroll.anchoredPosition = original;
    }

    IEnumerator DisplayScroll(float speed, float height)
    {
        while (creditsScroll.anchoredPosition.y < height)
        {
            creditsScroll.anchoredPosition += new Vector2(0, scrollStep);
            yield return new WaitForSeconds(speed);
        }
    }

    /// <summary>
    /// Begin 'typing' text into the credits text.
    /// </summary>
    /// <param name="lines">String array with the lines to be displayed.</param>
    /// <param name="pauseTime">Time to pause with the finished writing on screen in seconds as a float value.</param>
    /// <returns>To allow yielding for it to finish.</returns>
    protected IEnumerator StartTyped(string[] lines, float pauseTime)
    {
        yield return StartCoroutine(DisplayTyped(lines, typedDelay));
        yield return new WaitForSeconds(pauseTime);
        creditsText.text = "";
    }

    IEnumerator DisplayTyped(string[] lines, float delay)
    {
        int stringIndex = 0;
        int characterIndex = 0;
        string text = "";

        while (stringIndex < lines.Length)
        {
            yield return new WaitForSeconds(delay);
            if (characterIndex > lines[stringIndex].Length)
            {
                text += lines[stringIndex] + "\n";
                stringIndex++;
                characterIndex = 0;

                if (stringIndex >= lines.Length)
                {
                    continue;
                }
            }

            creditsText.text = text + lines[stringIndex].Substring(0, characterIndex); ;
            characterIndex++;
        }
    }

}
