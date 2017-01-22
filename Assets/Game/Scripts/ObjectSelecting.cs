using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//ObjectSelecting
//This object can be put on the camera, but it doesn't have to be. 
//But it does need to know the game view camera. Drag it into the variable field.
public class ObjectSelecting : MonoBehaviour
{

    public Camera Cam;

    private void Awake()
    {

    }

    private void Start()
    {
        if (Cam == null)
        {
            Cam = FindObjectOfType<Camera>();
            if (Cam != null)
            {
                Debug.Log("Camera not assigned, using first found camera.\n");
            }
            else
            {
                Debug.LogError("There's no camera! Please add a camera and assign it to this.\n");
            }
        }
    }



    private void Update()
    {
        detectClickOnObject();
    }

    private void detectClickOnObject()
    {
        if (Input.GetMouseButtonDown(0))
        { // if left button pressed...
            Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //valid found object
                if (hit.transform.gameObject.GetComponent<FoundObject>() != null)
                {
                    handleFoundObject(hit.transform.gameObject.GetComponent<FoundObject>());
                }
                else
                {
                    //Debug.Log("No click on FoundObject\n");
                    return;
                }
            }
            else
            {
                //Debug.Log("no hit\n");
            }
        }
    }

    private void handleFoundObject(FoundObject foundOb)
    {
        //Debug.Log("hit found object\n");
        if (foundOb.ObjectType == FoundObjects.Mundane)
        {
            handleMundaneObject(foundOb);
        }
        else
        {
            sendTextureToPuzzle(foundOb.PuzzleTexture);
        }
    }

    private void sendTextureToPuzzle(Texture texture)
    {
        Debug.Log("Hook into puzzle, please\n");
        //TODO - hook into Puzzle
    }

    private void handleMundaneObject(FoundObject foundOb)
    {
        //If we have time, do something with mundanes
    }
}
