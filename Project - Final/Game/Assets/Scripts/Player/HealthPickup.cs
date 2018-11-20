using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {

	PlayerHealth Playerhealth;

	public float healthAdd = 10f;

	void Awake() 
	{
		Playerhealth = FindObjectOfType<PlayerHealth>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (Playerhealth.currentHealth <Playerhealth.maxHealth)
		{
			Destroy (gameObject);
			Playerhealth.currentHealth = Playerhealth.currentHealth + healthAdd;
		}
    }
}
