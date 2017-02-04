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
        string[] linesFade = new string[] { "<size=100>Echoes</size>" };

        yield return BlankPause(4.0f);
        yield return StartTyped(linesTyped, 4.0f);
        yield return BlankPause(2.0f);
        yield return StartFade(linesFade, 1.0f, 3.0f);
        yield return BlankPause(6.0f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");
        //TODO scene transition into the main game here
    }
}
