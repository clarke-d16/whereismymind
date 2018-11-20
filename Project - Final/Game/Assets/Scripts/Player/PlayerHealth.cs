using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	[SerializeField]
	Slider healthBar;
	[SerializeField]
	Text healthText;

	[SerializeField]
	int enemyDamage;

	public float maxHealth = 100f;
	public float currentHealth;

	void Start()
	{
		healthBar.value = maxHealth;
		currentHealth = healthBar.value;
	}
		

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") 
		{
			healthBar.value -= enemyDamage;
			currentHealth = healthBar.value;
		}
	}

	void Update() {
		{
			healthText.text = currentHealth.ToString () + "%";
		}

        if(maxHealth > 100)
        {
            currentHealth = healthBar.value = 100f;
        }

        if (currentHealth <= 0)
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
		} 
	}
}