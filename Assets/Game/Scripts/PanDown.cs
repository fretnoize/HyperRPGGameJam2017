using UnityEngine;

public class PanDown : MonoBehaviour {

	// enables speed adjustment in Unity UI
	public float speed;

	// disables the pan until "Play Game" is clicked and thus `Pan ()` is called
	private bool clicked = false;

	// Update is called once per frame
	void Update () {
		// if "Play Game" was clicked, start to pan down every frame
		if (clicked) {
			transform.Translate (0, -transform.position.y * speed * Time.deltaTime, 0);
		}
	}

	// starts panning down
	public void Pan () {
		clicked = true;
	}
}
