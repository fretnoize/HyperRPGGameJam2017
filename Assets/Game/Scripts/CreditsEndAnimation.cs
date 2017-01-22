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
            // TODO something to exit the credits
        }
    }
	
    IEnumerator DisplayCredits()
    {
        string[] linesTyped = new string[] { "This was a TeamThumper production." };
        string[][] linesFade = new string[][] {
            new string[] {
                "<size=32><b>Game Directors</b></size>", "Malika Lim", "Patrick “Krund” Quinn", "",
                "<size=32><b>Lead Writer</b></size>", "Peter V. Baikun"
            },
            new string[] {
                "<size=32><b>Art Directors</b></size>", "Jennifer “aminim00se” Cleary", "Malika Lim", "",
                "<size=32><b>Lead UI</b></size>", "Razeruk"
            },
            new string[] {
                "<size=32><b>Lead Programmer</b></size>", "Padarr", "",
                "<size=32><b>Lead Quality Assurance</b></size>", "Kristal “Lady Kakyuu” Rupard"
            },
            new string[] {
                "<size=32><b>Music</b></size>", "Poor Alexei - ‘Interiors’", "Visager - ‘Village Dreaming’", "Aaron C. Edwards - ‘Don’t Cry’"
            },
            new string[] {
                "<size=32><b>Special Thanks</b></size>", "To the thumper community and HyperRPG", "To the Global Game Jam", "And you the player."
            },
        };
        string[] linesScroll = new string[] {
            "<size=32><b>Writers</b></size>", "Person 1", "Person 2", "",
            "<size=32><b>Programmers</b></size>", "Person 1", "Person 2", "",
            "<size=32><b>Artists</b></size>", "Person 1", "Person 2", "",
            "<size=32><b>Sound Designers</b></size>", "Person 1", "Person 2", "",
            "<size=32><b>Voice Actors</b></size>", "Person 1", "Person 2", "",
            "<size=32><b>Testers</b></size>", "Person 1", "Person 2", "",
        };

        yield return BlankPause(1.0f);
        yield return StartTyped(linesTyped, 2.0f);
        yield return BlankPause(1.0f);
        yield return StartFade(linesFade[0], 1.0f, 2.0f);
        yield return StartFade(linesFade[1], 1.0f, 2.0f);
        yield return StartFade(linesFade[2], 1.0f, 2.0f);
        yield return StartFade(linesFade[3], 1.0f, 2.0f);
        yield return StartScroll(linesScroll);
        yield return StartFade(linesFade[4], 1.0f, 4.0f);
        yield return BlankPause(1.0f);
        creditsText.text = "Thank you for playing and we hope you enjoyed the game.";
    }
}
