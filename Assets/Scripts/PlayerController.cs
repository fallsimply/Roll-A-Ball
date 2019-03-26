using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public float speed;
	public int marginOfError;
	public Text countText;
	public Text winText;
	private int count;
	private Rigidbody rb;
	private int totalCollectables;

	void Start() {
		rb = GetComponent<Rigidbody>();
		count = 1;
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
		if (other.gameObject.CompareTag("Collectable")) {
			other.gameObject.SetActive(false);
			count++;
			SetCountText();
		}
	}

	void SetCountText() {
		countText.text = $"Count: {count.ToString()}";
		if (count >= (totalCollectables - marginOfError)) {
			winText.text = "You Win!";
		}
	}

	void SetTotalCollectables() {
		totalCollectables = GameObject.FindGameObjectsWithTag("Collectable").Length;
	}
}
