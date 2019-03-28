using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	public int[] platforms;
	public GameObject[] doors;
	private int count = 0;
	private Rigidbody rb;
	private int totalCollectables;
	private int level = 0;
	private int bad = 0;


	void Start() {
		rb = GetComponent<Rigidbody>();
		SetTotalCollectables();
		SetCountText();
		winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Good")) {
			other.gameObject.SetActive(false);
			count++;
			CheckPlatformCompleted();
		} else if (other.gameObject.CompareTag("Bad")) {
			other.gameObject.SetActive(false);
			bad++;
		} else if (other.gameObject.CompareTag("Best")) {
			other.gameObject.SetActive(false);
			count += 3;
		}
		SetCountText();
	}

	void SetCountText() {
		countText.text = $"Count: {(count - bad).ToString() }";
		if (count >= totalCollectables) {
			winText.text = "You Win!";
		}
	}

	void SetTotalCollectables() {
		totalCollectables = platforms[(platforms.Length - 1)];
	}

	void ToggleDoor(int index = 0) {
		var obj = doors[(index)];
		obj.SetActive(!obj.activeSelf);
	}

	void CheckPlatformCompleted() {
		if (platforms[level] == count) {
			ToggleDoor(level);
			level++;
		};
	}
}
