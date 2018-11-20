using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCard : MonoBehaviour {

	public float time = 2;

	IEnumerator Start()
	{
		yield return new WaitForSeconds (time);
		Destroy (gameObject);
	}
}
