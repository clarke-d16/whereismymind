using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpawnPoint : MonoBehaviour {

	public GameObject spawnPoint;
	public GameObject Player;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{

	}

	public void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player") 
		{
			Player.transform.position = new Vector2 (spawnPoint.transform.position.x, spawnPoint.transform.position.y);
		}
	}
}