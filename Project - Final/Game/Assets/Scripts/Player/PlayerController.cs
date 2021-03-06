using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{
	[SerializeField]
	private GameObject firePrefab;

	[SerializeField]
	private Blockades[] blockades;

	[SerializeField]
	private Transform[] exitPoints;

	private int exitIndex = 3;

	public Transform target { get; set;}

	protected override void Start ()
	{
		//target = GameObject.Find ("Enemy").transform;
		base.Start ();
	}

	// Update is called once per frame
	protected override void Update()
	{
		GetInput ();
		//Debug.Log(LayerMask.GetMask("Wall"));
		base.Update ();
	}

	private void GetInput() {

		direction = Vector2.zero;

		if (Input.GetKey (KeyCode.W)) {
			exitIndex = 0;
			direction += Vector2.up;
			GetComponent<AudioSource> ().UnPause ();
		}

		else
		{
			GetComponent<AudioSource> ().Pause();
		}

		if(Input.GetKey(KeyCode.D))
		{
			exitIndex = 1;
			direction += Vector2.right;
			GetComponent<AudioSource> ().UnPause ();
		}

		if (Input.GetKey(KeyCode.A))
		{
			exitIndex = 2;
			direction += Vector2.left;
			GetComponent<AudioSource> ().UnPause ();
		}

		if (Input.GetKey(KeyCode.S))
		{
			exitIndex = 3;
			direction += Vector2.down;
			GetComponent<AudioSource> ().UnPause ();
		}


		if (Input.GetKeyDown(KeyCode.Space)) 
		{
			Blockade ();

			if (target != null && !isShooting && !isMoving && InProximity())
			{
				shootCoroutine = StartCoroutine (Shoots ());
			}
		}
	}

	private IEnumerator Shoots()
	{
		Transform currentTarget = target;

		isShooting = true;
		anim.SetBool ("cast", isShooting);
		yield return new WaitForSeconds (1);

		if (currentTarget != null && InProximity()) 
		{
			Shoot f = Instantiate (firePrefab, exitPoints [exitIndex].position, Quaternion.identity).GetComponent<Shoot> ();
			f.target = currentTarget;
		}

		StopShooting ();
	}

	private bool InProximity()
	{
		if (target != null)
		{
			Vector3 enemyDirection = (target.transform.position - transform.position).normalized;

			//Debug.DrawRay (transform.position, enemyDirection, Color.blue);
			RaycastHit2D hit = Physics2D.Raycast (transform.position, enemyDirection, Vector2.Distance (transform.position, target.transform.position), 1024);

			if (hit.collider == null) {
				return true;
			}
		}

		return false;
	}

	private void Blockade()
	{
		foreach (Blockades b in blockades) 
		{
			b.DeActivate ();
		}

		blockades [exitIndex].Activate ();
	}
}