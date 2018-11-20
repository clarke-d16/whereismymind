using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour {

	protected float delayRestart = 2f;
	private float timer = 120f;
	private Text timerSeconds;


	// Use this for initialization
	void Start () 
	{
		timerSeconds = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () 
	{
		timer -= Time.deltaTime;
		timerSeconds.text = timer.ToString ("f2");
		if (timer < 0)
		{
			Invoke ("Restart", delayRestart);
			SceneManager.LoadScene (6);
		}
	}
}