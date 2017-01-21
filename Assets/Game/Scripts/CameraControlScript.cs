using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
	private int xspeed = 20;
	// Use this for initialization
	void Start ()
	{
		Camera camera = null;
		Camera[] cameras = Camera.allCameras;
		foreach (Camera item in cameras) {
			if (item.name.Equals ("PlayerCamera")) {
				camera = item;
			}
		}
		if (camera == null) {
			Debug.Log ("PlayerCamera not found");
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log ("Updating camera position by reading input. Adjusting camera ");
		// Note this does not yet wrap
		// Moving the camera to the right
		if (rightArrowDown ()) {
			transform.Translate (Vector2.right * xspeed * Time.deltaTime);
		} else if (leftArrowDown ()) {
			transform.Translate (Vector2.left * xspeed * Time.deltaTime);
		} else {
			return;
		}
	}

	private bool rightArrowDown ()
	{
		return Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKey (KeyCode.RightArrow);
	}

	private bool leftArrowDown ()
	{
		return Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.LeftArrow);
	}
}
