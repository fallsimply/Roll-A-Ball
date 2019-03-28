using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour {
	public Button button;
	// Start is called before the first frame update
	void Start() {
		button.onClick.AddListener(OnClick);
	}
	void OnClick() {
		Application.Quit();
	}
}
