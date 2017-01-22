using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsAnimation : CreditsTools {
    void Start () {
        StartCoroutine(DisplayCredits());
    }

    void Update () {
        if ()
        {

        }
    }
	
    IEnumerator DisplayCredits()
    {
        string[] linesTyped = new string[] { "This will be typed out in the middle of the screen." };
        string[] linesFade = new string[] { "This should fade in and out." };
        string[] linesScroll = new string[] { "<b>Title</b>", "Person 1", "Person 2", "", "<b>Title</b>", "Person 1", "Person 2" };

        yield return StartTyped(linesTyped);
        yield return StartScroll(linesScroll);
        creditsText.text = "Scrolling done!";
        yield return 0;
    }
}
