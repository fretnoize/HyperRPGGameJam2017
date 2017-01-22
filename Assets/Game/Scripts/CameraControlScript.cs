// seem unnecessary
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class CameraControlScript : MonoBehaviour
{
	// `public` allows this parameter to be adjusted within the Unity UI, convenient for those outside of the Programming team
	public float xspeed = 20;

	// this is the backdrop texture/sprite for the scene, used to tell the camera where the edge of the scene is
	public SpriteRenderer backdrop;

	// Use this for initialization
	/*void Start ()
	{

	}*/

	// LateUpdate is called once per frame, after all items have been processed in `Update`
	// So that the player or any other objects have moved and updated
	void LateUpdate ()
	{
		// Debug.Log ("Updating camera position by reading input. Adjusting camera ");

		// seems a more general form of getting "left/right" user input. Both arrow keys and WASD
		float moveHorizontal = Input.GetAxis ("Horizontal");

		// wrapping the camera to the other side of the scene
		// `backdrop.bounds.max.x` is the rightmost edge of the backdrop (pos x) while `min` is the leftmost edge
		if (transform.position.x > backdrop.bounds.max.x) {
			// seems the `z` variable needs to be set to -10, at least occasionally. Otherwise the camera will end up at z = 1
			transform.position = new Vector3 (backdrop.bounds.min.x, 0, -10);
		} else if (transform.position.x < backdrop.bounds.min.x) {
			transform.position = new Vector3 (backdrop.bounds.max.x, 0, -10);
		}

		// `Input.GetAxis ("Horizontal")` allows a single `Translate` statement and does the work of "left/right" for us
		Vector2 movement = new Vector2 (moveHorizontal, 0);

		transform.Translate (movement * xspeed * Time.deltaTime);

		/*// Moving the camera to the right
		if (rightArrowDown ()) {
			transform.Translate (Vector2.right * xspeed * Time.deltaTime);
		} else if (leftArrowDown ()) {
			transform.Translate (Vector2.left * xspeed * Time.deltaTime);
		} else {
			return;
		}*/
	}

	// see `Input.GetAxis` above
	/*private bool rightArrowDown ()
	{
		return Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKey (KeyCode.RightArrow);
	}

	private bool leftArrowDown ()
	{
		return Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKey (KeyCode.LeftArrow);
	}*/
}
