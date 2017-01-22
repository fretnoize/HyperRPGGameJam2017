using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsEndAnimation : CreditsTools {
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
        string[][] linesFade = new string[][] {
            new string[] {
                "<b>Game Directors</b>", "Malika Lim", "Patrick “Krund” Quinn", "",
                "<b>Lead Writer</b>", "Peter V. Baikun"
            },
            new string[] {
                "<b>Art Directors</b>", "Jennifer “aminim00se” Cleary", "Malika Lim", "",
                "<b>Lead UI</b>", "Razeruk"
            },
            new string[] {
                "<b>Lead Programmer</b>", "Padarr", "",
                "<b>Lead Quality Assurance</b>", "Kristal “Lady Kakyuu” Rupard"
            },
            new string[] {
                "<b>Music</b>", "Poor Alexei - ‘Interiors’", "Visager - ‘Village Dreaming’", "Aaron C. Edwards - ‘Don’t Cry’"
            },
            new string[] {
                "<b>Special Thanks</b>", "To the thumper community and HyperRPG", "To the Global Game Jam", "And you the player."
            },
        };
        string[] linesScroll = new string[] {
            "<b>Writers</b>", "Person 1", "Person 2", "",
            "<b>Programmers</b>", "Person 1", "Person 2", "",
            "<b>Artists</b>", "Person 1", "Person 2", "",
            "<b>Sound Designers</b>", "Person 1", "Person 2", "",
            "<b>Voice Actors</b>", "Person 1", "Person 2", "",
            "<b>Testers</b>", "Person 1", "Person 2", "",
        };

        yield return BlankPause(1.0f);
        yield return StartTyped(linesTyped, 2.0f);
        yield return BlankPause(1.0f);
        yield return StartFade(linesFade[0], 1.0f, 2.0f);
        yield return StartFade(linesFade[1], 1.0f, 2.0f);
        yield return StartFade(linesFade[2], 1.0f, 2.0f);
        yield return StartFade(linesFade[3], 1.0f, 2.0f);
        yield return StartScroll(linesScroll);
        yield return StartFade(linesFade[4], 1.0f, 2.0f);
        yield return BlankPause(1.0f);
        creditsText.text = "Thank you for playing and we hope you enjoyed the game.";
    }
}
