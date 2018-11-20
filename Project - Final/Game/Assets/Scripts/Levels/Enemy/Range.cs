using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour {

	private EnemyController parent;
	private Transform target;

	void Start()
	{
		parent = GetComponentInParent<EnemyController> ();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") 
		{
			parent.Target = collision.transform;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "Player") 
		{
			parent.Target = null;
		}
	}
}
