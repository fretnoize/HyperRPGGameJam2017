using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

	static GameObject[] menuObjects;
	static GameObject[] optionsObjects;
	static bool optionsMenu;
	static bool mainMenu;

	AudioSource audio;
	public Slider volumeSlider;
	public AudioSource volumeAudio;


	void Start () {
		menuObjects = GameObject.FindGameObjectsWithTag ("MainMenu");
		optionsObjects = GameObject.FindGameObjectsWithTag ("Options");

		audio = GetComponent<AudioSource>();

		toggleOptions();


	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			toggleOptions ();
		}
		
	}

	public void LoadGame() {
		toggleMenu ();

	}

	public void Options() {
		UIController.toggleOptions ();
		UIController.toggleMenu ();
	}

	public void Back() {
		UIController.toggleOptions ();
		UIController.toggleMenu ();
	}

	private static void toggleOptions() {
		foreach (GameObject o in optionsObjects) {
			o.SetActive (optionsMenu);
		}
		toggleOptionsState ();
	}

	private static void toggleMenu() {
		foreach (GameObject m in menuObjects) {
			m.SetActive (mainMenu);
		}
		toggleMenuState ();
	}

	public void MuteSound() {
		if (audio.mute)
			audio.mute = false;
		else
			audio.mute = true;
	}

	public void VolumeController() {
		volumeSlider.value = volumeAudio.volume;
	}

	public void exitApplication(){
		Application.Quit ();
	}

	private static void toggleOptionsState() {
		UIController.optionsMenu = !UIController.optionsMenu;
	
	}

	private static void toggleMenuState() {
		UIController.mainMenu = !UIController.mainMenu;

	}
}
