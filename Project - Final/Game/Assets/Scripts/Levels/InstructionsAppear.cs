using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsAppear : MonoBehaviour {


	[SerializeField]
	public GameObject instructionsUI;

	public static int nurseCountValue;

	//public Text nurseStat;

	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
		//nurseStat = GetComponent<Text> ();
	}

	void Update()
	{
		try
		{
		//nurseStat.text = "You have consoled in the nurses " + nurseCountValue + " times";
		}

		catch 
		{
			Debug.Log ("Error");
		}
	}


	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") {
			audioSource.Play ();
			nurseCountValue += 1;
			instructionsUI.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {
			instructionsUI.SetActive (false);
		}
	}
}
