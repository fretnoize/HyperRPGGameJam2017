using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsBeginAnimation : CreditsTools
{
    void Start()
    {
        StartCoroutine(DisplayCredits());
    }

    IEnumerator DisplayCredits()
    {
        string[] linesTyped = new string[] { "TeamThumper presents..." };
        string[] linesFade = new string[] { "The Thumpening!", "(aka insert title here)" };

        yield return BlankPause(1.0f);
        yield return StartTyped(linesTyped, 3.0f);
        yield return BlankPause(1.0f);
        yield return StartFade(linesFade, 1.0f, 3.0f);
        yield return BlankPause(1.0f);

        //TODO scene transition into the main game here
    }
}
