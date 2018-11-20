using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private PlayerController player;

	private Character currentTarget;

	public Text nurseStat;
	public Text enemyStat;

	public static GameManager Instance;

	void Awake()
	{
		if (Instance == null) {
			DontDestroyOnLoad (gameObject);
			Instance = this;
		}
	}

	// Update is called once per frame
	void Update () 
	{
		ClickEnemy ();
		//Debug.Log(LayerMask.GetMask("Enemy"));	
	}

	private void ClickEnemy()
	{
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, Mathf.Infinity, 4096);
			//Targets the enemy
			if (hit.collider != null) {
				if (currentTarget != null) {
					currentTarget.DeSelect ();
				}

				currentTarget = hit.collider.GetComponent<Character> ();
				try {
					player.target = currentTarget.Select ();
				} catch {
					Debug.Log ("Error");
				}
			}
					
			 else 
				{
				if (currentTarget != null) {
					currentTarget.DeSelect ();
				}
				currentTarget = null;
				player.target = null;
			}
		}
	}
}