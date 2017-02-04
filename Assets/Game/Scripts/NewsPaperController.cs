using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsPaperController : MonoBehaviour
{
    public GameObject[] Pages;

    public static bool Displayed; //all pages seen

    [HideInInspector]
    public bool NewsPaperInputLock; //lock for newspaper control

    private int iterator = 0;
    
    public InstructionsController Instructions;

    void Start ()
    {
        if (Displayed)
        {
            gameObject.SetActive(false);
        }
	}
	

	void Update ()
    {
        bool advance = ( Input.GetKeyDown(KeyCode.D) 
                      || Input.GetKeyDown(KeyCode.RightArrow)
                      || Input.GetMouseButtonDown(0));

        bool retreat = ( Input.GetKeyDown(KeyCode.A)
                      || Input.GetKeyDown(KeyCode.LeftArrow)
                      || Input.GetMouseButtonDown(1));

        if (!Displayed && advance)
        {
            displayPage();
        }
        else if ( (iterator > 0) && retreat )
        {
            hidePage();
        }
	}

    private void OnEnable()
    {
        if (!Displayed)
        {
            NewsPaperInputLock = true;
            displayPage();
        }
    }

    private void displayPage()
    {
        foreach (GameObject ob in Pages)
        {
            ob.SetActive(false);
        }

        Pages[iterator].SetActive(true);
        ++iterator;
        if (iterator >= Pages.Length)
        {
            Displayed = true;
            gameObject.SetActive(false);
            NewsPaperInputLock = false;
            Instructions.gameObject.SetActive(true);
        }
    }

    private void hidePage()
    {
        Pages[iterator].SetActive(false);
        --iterator;
        Pages[iterator].SetActive(true);
    }
}
