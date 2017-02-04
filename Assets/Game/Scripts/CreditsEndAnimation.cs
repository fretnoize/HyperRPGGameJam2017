using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsEndAnimation : CreditsTools {
    void Start () {
        StartCoroutine(DisplayCredits());
    }

    void Update () {
        if (Input.anyKeyDown)
        {
            Application.Quit();
            //UnityEngine.SceneManagement.SceneManager.LoadScene("Main Scene");
        }
    }
	
    IEnumerator DisplayCredits()
    {
        string[] linesTyped = new string[] { "This was a TeamThumper production." };
        string[][] linesFade = new string[][] {
            new string[] {
                "<size=32><b>Producer</b></size>", "Malika Lim", "",
                "<size=32><b>Game Director</b></size>", "Patrick “Krund” Quinn", "",
                "<size=32><b>Lead Writer</b></size>", "Peter V. Baikun"
            },
            new string[] {
                "<size=32><b>Art Directors</b></size>", "Jennifer “aminim00se” Cleary", "Malika Lim", "",
                "<size=32><b>Lead UI</b></size>", "Razeruk"
            },
            new string[] {
                "<size=32><b>Lead Programmers</b></size>", "Padarr", "Eurghsireawe", "",
                "<size=32><b>Lead Quality Assurance</b></size>", "Kristal “Lady Kakyuu” Rupard"
            },
            new string[] {
                "<size=32><b>Music</b></size>", "Fretnoize - Opening Credits", "Aaron C. Edwards - ‘Don’t Cry’"
            },
            new string[] {
                "<size=32><b>Special Thanks</b></size>", "To the thumper community and HyperRPG", "To the Global Game Jam", "And you the player"
            },
        };
        string[] linesScroll = new string[] {
            "<size=32><b>Writers</b></size>", "Dgwritingfiend", "Stephen “Xjere” Zalar", "Bonebumble", "Louis “SillySonny” Goodwin", "",
            "<size=32><b>Programmers</b></size>", "Anna M. Berg", "Nick “quiet_geek” Elliott", "Fretnoize", "KyuuiPenguin",  "",
            "<size=32><b>Artists</b></size>", "Jennifer “aminim00se” Cleary", "",
            "<size=32><b>Sound Designer</b></size>", "Dgwritingfiend", "",
            "<size=32><b>Sound Consultant</b></size>", "Louis “SillySonny” Goodwin", "",
            "<size=32><b>Voice Actors</b></size>", "Child - Kristal “Lady Kakyuu” Rupard", "Father - Patrick “Krund” Quinn", "Politician - Jennifer “aminim00se” Cleary", "Scientist - Louis “SillySonny” Goodwin", "",
            "<size=32><b>Testers</b></size>", "KyuuiPenguin", "Louis “SillySonny” Goodwin", "Joninyan",
        };

        yield return BlankPause(1.0f);
        yield return StartTyped(linesTyped, 2.0f);
        yield return BlankPause(1.0f);
        yield return StartFade(linesFade[0], 1.0f, 2.0f);
        yield return StartFade(linesFade[1], 1.0f, 2.0f);
        yield return StartFade(linesFade[2], 1.0f, 2.0f);
        yield return StartFade(linesFade[3], 1.0f, 2.0f);
        yield return StartScroll(linesScroll);
        yield return StartFade(linesFade[4], 1.0f, 6.0f);
        yield return BlankPause(1.0f);
        creditsText.text = "Thank you for playing and we hope you enjoyed the game.";
    }
}
