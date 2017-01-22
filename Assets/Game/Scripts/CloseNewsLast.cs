using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CloseNewsLast : MonoBehaviour {


	public GameObject news;
	public Button current;
	public Scrollbar vertical;
	public Scrollbar horizontal;

	public GameObject instruction;

	// Use this for initialization
	void Start () {
		Button btn = current.GetComponent<Button>();
		btn.onClick.AddListener(ActivateNextClose);

		instruction.SetActive (false);
		horizontal.interactable = false;
		vertical.interactable = false;
		current.interactable = false;
	}

	void ActivateNextClose(){
		instruction.SetActive (true);
		news.SetActive(false);
	}
	// Update is called once per frame
	void Update () {

	}
}
