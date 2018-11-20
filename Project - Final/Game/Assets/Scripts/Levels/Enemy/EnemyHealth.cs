using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : Character {

	[SerializeField]
	private CanvasGroup healthGroup;

	[SerializeField]
	Slider enemyHealthBar;

	//public static int enemyCountValue;

	//public Text enemyStat;
	[SerializeField]
	public float maxHealth;
	public float currentHealth;

	public override Transform Select()
	{
		healthGroup.alpha = 1;
		return base.Select ();
	}

	protected override void Start()
	{
		try
		{
		//enemyStat = GetComponent<Text> ();
		}
	
		catch 
		{
			Debug.Log ("Error");
		}

		enemyHealthBar.value = maxHealth;
		currentHealth = enemyHealthBar.value;
	}
		
	void Update()
	{
		try
		{
			//enemyStat.text = "You have killed " + enemyCountValue + " times";
		}

		catch 
		{
			Debug.Log ("Error");
		}
	}
		
	void OnTriggerEnter2D(Collider2D collide)
	{
		if (collide.gameObject.tag == "Fire") 
		{
			enemyHealthBar.value -= 5f;
			currentHealth = enemyHealthBar.value;
		}
	}

    public void Damage(float damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            enemyDeath();
        }
    }

    void enemyDeath()
    {
		//enemyCountValue += 1;
        Destroy(gameObject);
        Destroy(transform.parent.gameObject);
    }
}