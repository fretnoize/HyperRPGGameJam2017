using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperToggle : MonoBehaviour
{
    public GameObject Newspapers;

	void Update ()
    {
        if (!Assets.Game.Scripts.UiController.optionsMenu || !Assets.Game.Scripts.UiController.mainMenu)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            Newspapers.SetActive(!Newspapers.activeSelf);
        }

    }
}
