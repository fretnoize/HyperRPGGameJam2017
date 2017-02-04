using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsController : MonoBehaviour
{

    public static bool Displayed;
    public bool Unlocked;

	// Use this for initialization
	void OnEnabled ()
    {
        if (Displayed)
        {
            gameObject.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.anyKeyDown)
        {
            Displayed = true;
            gameObject.SetActive(false);
        }
	}
}
