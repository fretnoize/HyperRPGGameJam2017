using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//FoundObject
//FoundObject should be added to any game object the player is expected to be able to click on.
//Assign the type of object it should be, and assign the texture that will be used if it's not a Mundane object. 
//There are rules for how the texture should be set up, read/write 
//need to be enabled under advanced settings and filter type to point, 
//this info also comes up as a tool tip, hover over the texture field.
public class FoundObject : MonoBehaviour
{
    public FoundObjects ObjectType;

    [Tooltip("Be sure this texture has: Advanced Settings-> Read/Write Enabled, and filter type is point")]
    public Texture PuzzleTexture;

    private void Start()
    {
        if (PuzzleTexture == null && ObjectType != FoundObjects.Mundane)
        {
            Debug.LogError("This non-mundane FoundObject doesn't have a texture assigned\n");
        }
    }


}
