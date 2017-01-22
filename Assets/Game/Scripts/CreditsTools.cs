using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsTools : MonoBehaviour {
    public RectTransform creditsScroll;
    public Text creditsText;
    public float scrollDelay = 0.1f;
    public float typedDelay = 0.1f;

    protected bool running = true;

    protected IEnumerator StartScroll(string[] lines)
    {
        RectTransform canvas = gameObject.GetComponent<RectTransform>();
        print(canvas.rect.height);
        print(canvas.rect.width);

        Vector2 original = creditsScroll.anchoredPosition;
        creditsScroll.anchoredPosition = new Vector2(0, -400);

        string textScroll = "";
        for (int i=0; i<lines.Length; i++)
        {
            textScroll += lines[i] + "\n";
        }

        creditsText.text = textScroll;

        yield return StartCoroutine(DisplayScroll(scrollDelay, 750));

        creditsText.text = "";
        creditsScroll.anchoredPosition = original;
    }

    IEnumerator DisplayScroll(float speed, float height)
    {
        while (creditsScroll.anchoredPosition.y < height)
        {
            creditsScroll.anchoredPosition += Vector2.up;
            yield return new WaitForSeconds(speed);
        }

        yield return 0;
    }

    protected IEnumerator StartTyped(string[] lines)
    {
        yield return StartCoroutine(DisplayTyped(lines, typedDelay));
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

        yield return 0;
    }

}
