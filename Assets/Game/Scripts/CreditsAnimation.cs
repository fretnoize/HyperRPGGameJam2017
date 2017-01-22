using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsAnimation : CreditsTools {
    void Start () {
        StartCoroutine(DisplayCredits());
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // TODO something to exit the menu
        }
    }
	
    IEnumerator DisplayCredits()
    {
        string[] linesTyped = new string[] { "This was a TeamThumper production." };
        string[] linesFade = new string[] { "This should fade in and out." };
        string[] linesScroll = new string[] { "<b>Title</b>", "Person 1", "Person 2", "", "<b>Title</b>", "Person 1", "Person 2" };

        //yield return StartTyped(linesTyped);
        yield return StartFade(linesFade, 1.0f, 1.0f);
        yield return StartScroll(linesScroll);
        creditsText.text = "Scrolling done!";
        yield return 0;
    }
}
