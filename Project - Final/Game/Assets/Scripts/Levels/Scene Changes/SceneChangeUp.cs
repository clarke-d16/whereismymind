using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeUp : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player") {
			int scene = SceneManager.GetActiveScene ().buildIndex;
			if (scene < SceneManager.sceneCountInBuildSettings)
				SceneManager.LoadScene (scene + 1);
		}
	}
}