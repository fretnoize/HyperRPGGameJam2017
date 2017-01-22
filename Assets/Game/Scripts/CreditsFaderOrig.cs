using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsFaderOrig : MonoBehaviour {
    public Text credits;
    public float start = 255f;
    public float end = 0f;
    public float delay = 0.1f;

    private float progress;
    private float r;
    private float g;
    private float b;

	// Use this for initialization
	void Start () {
        progress = start;
        r = credits.color.r;
        g = credits.color.g;
        b = credits.color.b;

        StartCoroutine(DisplayFade());
	}

    IEnumerator DisplayFade()
    { 
        while (progress > 0.0f)
        {
            yield return new WaitForSeconds(delay);
            credits.color = new Color(progress, progress, progress);
            progress--;
            print(progress);
        }

        yield return 0;
    }

/*
    IEnumerator DisplayTimer()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(speed);
            if (characterIndex > strings[stringIndex].Length)
            {
                continue;
            }

            textArea.text = strings[stringIndex].Substring(0, characterIndex);
            characterIndex++;
        }
    }
*/

    // Update is called once per frame
    void Update () {
		
	}
}
