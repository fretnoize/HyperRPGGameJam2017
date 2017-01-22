using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseNewsFirst : MonoBehaviour {

	public GameObject news;
	public Button current;
	public Button nextButton;

	public Scrollbar nextVertical;
	public Scrollbar nextHorizontal;


	// Use this for initialization
	void Start () {
		Button btn = current.GetComponent<Button>();
		btn.onClick.AddListener(ActivateNextClose);
	}

	void ActivateNextClose(){
		nextButton.interactable = true;
		nextVertical.interactable = true;
		nextHorizontal.interactable = true;

		news.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
