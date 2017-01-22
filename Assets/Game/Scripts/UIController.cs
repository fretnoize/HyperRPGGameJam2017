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
	static bool mute;
	public Slider volumeSlider;
	//public float volumeS;
	//public AudioSource volumeAudio;


	void Start () {
		menuObjects = GameObject.FindGameObjectsWithTag ("MainMenu");
		optionsObjects = GameObject.FindGameObjectsWithTag ("Options");

		toggleOptions();

		volumeSlider = gameObject.GetComponent<Slider> ();
		volumeSlider.value = 1f;

	}
	
	void Update () {
		
		// press esc to open and cose the options menu
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
		if (mute == false) {
			AudioListener.volume = 0;
			//volumeSlider.value = 0;
		} 
		if (mute == true) {
			AudioListener.volume = 1f;
			//volumeSlider.value = 1f;
		}

		UIController.mute = !UIController.mute;
			
	}

	public void Volume() {
		AudioListener.volume = volumeSlider.value;
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
