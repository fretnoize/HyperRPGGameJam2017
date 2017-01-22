using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFadeInOut : MonoBehaviour
{
    public float fadeDuration = 3.0f;
    public float pauseDuration = 3.0f;

    // NOTE: does not actually work for some reason, despite internet saying it does

    /*
    private IEnumerator Start()
    {
        yield return StartCoroutine(Fade(0.0f, 1.0f, fadeDuration));
        yield return StartCoroutine(Fade(1.0f, 0.0f, fadeDuration));
        Destroy(gameObject);
    }

    private IEnumerator Fade(float startLevel, float endLevel, float time)
    {
        float speed = 1.0f / time;

        for (float t = 0.0f; t < 1.0; t += Time.deltaTime * speed)
        {
            float a = Mathf.Lerp(startLevel, endLevel, t);
            guiText.font.material.color = new Color(guiText.font.material.color.r,
                guiText.font.material.color.g,
                guiText.font.material.color.b, a);
            yield return 0;
        }
    }
    */
}