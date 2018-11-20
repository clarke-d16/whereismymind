using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAfterSeconds : MonoBehaviour {

	public float delay = 5;

	// Use this for initialization
	void Start () {

		StartCoroutine (LoadLevelAfterDelay (delay));
	}

	IEnumerator LoadLevelAfterDelay(float delay)
	{
		yield return new WaitForSeconds (delay);
		SceneManager.LoadScene (8);
	}
}
