using System;
using UnityEngine;

[Serializable]
public class Blockades 
{
	[SerializeField]
	private GameObject first, second;

	public void Activate()
	{
		first.SetActive (true);
		second.SetActive (true);
	}

	public void DeActivate()
	{
		first.SetActive (false);
		second.SetActive (false);
	}
}
