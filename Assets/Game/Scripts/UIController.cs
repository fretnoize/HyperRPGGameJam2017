using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

	// menu/options objects
	static GameObject[] menuObjects;
	static GameObject[] optionsObjects;
	static bool optionsMenu;
	static bool mainMenu;

	// audio
	public AudioSource audio;
	public Slider volumeSlider;
	// public AudioSource volumeAudio;


	void Start () {
		menuObjects = GameObject.FindGameObjectsWithTag ("MainMenu");
		optionsObjects = GameObject.FindGameObjectsWithTag ("Options");

		// if (audio == null)
		// {
		// 	audio = GetComponent<AudioSource>();
		// 	if (audio != null)
		// 	{
		// 		Debug.Log("audio not assigned, using first found AudioSource.\n");
		// 	} else {
		// 		Debug.LogError("There's no audio! Please add an audio source and assign it to this.\n");
		// 	}
		// }

		toggleOptions();
	}

	void Update () {

		// press esc to open and close the options menu
		if (Input.GetKeyDown (KeyCode.Escape)) {
			toggleOptions ();
		}
	}

	// removes the menu when the game begins
	public void LoadGame() {
		toggleMenu ();
	}

	// deactivates the main menu objects, activates the options objects
	public void Options() {
		UIController.toggleOptions ();
		UIController.toggleMenu ();
	}

	// opposite of above
	public void Back() {
		UIController.toggleOptions ();
		UIController.toggleMenu ();
	}

	// mutes sound
	public void MuteSound() {
		audio.mute = !audio.mute;
	}

	// controls volume
	public void VolumeController() {
		// volumeSlider.value = volumeAudio.volume;
		audio.volume = volumeSlider.normalizedValue;
	}

	// exits the game
	public void exitApplication(){
		Application.Quit ();
	}

	// avticates/deactivates the options objects
	private static void toggleOptions() {
		foreach (GameObject o in optionsObjects) {
			o.SetActive (optionsMenu);
		}
		UIController.optionsMenu = !UIController.optionsMenu;
	}

	// avticates/deactivates the main menu objects
	private static void toggleMenu() {
		foreach (GameObject m in menuObjects) {
			m.SetActive (mainMenu);
		}
		UIController.mainMenu = !UIController.mainMenu;
	}

}
