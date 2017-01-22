using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScroll : MonoBehaviour {
    public RectTransform scroll;
    public Text credits;
    public float delay;

	// Use this for initialization
	void Start () {
        RectTransform canvas = gameObject.GetComponentInParent<RectTransform>();
        print(canvas.rect.height);
        scroll.anchoredPosition = new Vector2(0.0f, -400.0f);

        StartCoroutine(DisplayScroll(delay));
	}

    IEnumerator DisplayScroll(float speed)
    {
        while (true) {
            yield return new WaitForSeconds(speed);
            scroll.anchoredPosition += Vector2.up;
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
