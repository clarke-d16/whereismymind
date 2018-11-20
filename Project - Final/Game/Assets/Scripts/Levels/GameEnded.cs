using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnded : MonoBehaviour {

	public bool isEnded = false;
	public GameObject gameOverUI;


	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			gameOverUI.SetActive (true);
			Time.timeScale = 0f;
			isEnded = true;
		}
	}
}
