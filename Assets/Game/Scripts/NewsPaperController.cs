using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperController : MonoBehaviour
{
    public GameObject[] Pages;

    //public static bool Displayed; //all pages seen

    [HideInInspector]
    public bool NewsPaperInputLock; //lock for newspaper control

    private int iterator = 0;
    
    public InstructionsController Instructions;
    
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.D)
                      || Input.GetKeyDown(KeyCode.RightArrow)
                      || Input.GetMouseButtonDown(0))
        {
            incrementPage();
            displayPage();
        }

        if (Input.GetKeyDown(KeyCode.A)
                      || Input.GetKeyDown(KeyCode.LeftArrow)
                      || Input.GetMouseButtonDown(1))
        {
            decrementPage();
            displayPage();
        }
	}

    private void OnEnable()
    {
        NewsPaperInputLock = true;
        displayPage();
        iterator = 0;
    }

    private void OnDisable()
    {
        NewsPaperInputLock = false;
    }

    private void displayPage()
    {
        foreach (GameObject ob in Pages)
        {
            ob.SetActive(false);
        }

        Pages[iterator].SetActive(true);
    }

    private void incrementPage()
    {
        ++iterator;
        if (iterator >= Pages.Length)
        {
            iterator = 0;
        }
    }

    private void decrementPage()
    {
        --iterator;
        if (iterator < 0)
        {
            iterator = Pages.Length - 1;
        }
    }
}
