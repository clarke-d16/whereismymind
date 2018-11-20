using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour {

	public Button level01Button, level02Button, level03Button, level04button;
	int levelPassed;

	// Use this for initialization
	void Start () {
		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		level01Button.interactable = false;
		level02Button.interactable = false;
		level03Button.interactable = false;

		switch (levelPassed) {
		case 1: 
			level01Button.interactable = true;
			break;
		case 2:
			level01Button.interactable = true;
			level02Button.interactable = true;
			break;
		case 3:
			level01Button.interactable = true;
			level02Button.interactable = true;
			level03Button.interactable = true;
			break;

		case 4:
			level01Button.interactable = true;
			level02Button.interactable = true;
			level03Button.interactable = true;
			level04button.interactable = true;
			break;
		}
	}

	public void levelToLoad(int level)
	{
		SceneManager.LoadScene (level);
	}

	public void resetPlayerPref()
	{
		level01Button.interactable = false;
		level02Button.interactable = false;
		level03Button.interactable = false;
		level04button.interactable = false;
		PlayerPrefs.DeleteAll ();
	}
}
