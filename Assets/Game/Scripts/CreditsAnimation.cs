using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsAnimation : MonoBehaviour {
    public RectTransform scroll;
    public Text credits;
    public float scrollDelay = 0.1f;

    private bool running = false;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator DisplayCredits()
    {
        yield return 0;
    }

    void DoScroll()
    {
        Vector2 original = scroll.anchoredPosition;
        scroll.anchoredPosition = new Vector2(0, -400);
        running = true;

        StartCoroutine(DisplayScroll(scrollDelay));

        // Hide here
        scroll.anchoredPosition = original;
    }

    IEnumerator DisplayScroll(float speed)
    {
        while (running)
        {
            scroll.anchoredPosition += Vector2.up;
            yield return new WaitForSeconds(speed);
        }

        yield return 0;
    }
}
