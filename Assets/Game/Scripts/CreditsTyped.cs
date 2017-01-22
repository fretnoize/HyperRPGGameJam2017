using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsTyped : MonoBehaviour {
    public Text textArea;
    public string[] strings;
    public float speed = 0.2f;

    private int stringIndex = 0;
    private int characterIndex = 0;

    private bool running = true;
    private string text = "";

    // Use this for initialization
    void Start () {
        StartCoroutine(DisplayTyped(strings));
	}

    IEnumerator DisplayTyped(string[] lines)
    {
        while (running)
        {
            yield return new WaitForSeconds(speed);
            if (characterIndex > lines[stringIndex].Length)
            {
                text += lines[stringIndex] + "\\n";
                stringIndex++;
                characterIndex = 0;

                if (stringIndex >= lines.Length)
                {
                    running = false;
                    continue;
                }
            }

            textArea.text = text + lines[stringIndex].Substring(0, characterIndex); ;
            characterIndex++;
        }

        yield return 0;
    }
}
