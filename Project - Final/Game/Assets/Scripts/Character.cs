using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	protected float moveSpeed;
	protected Animator anim;
	protected Rigidbody2D rBody;

	protected Vector2 direction;

	protected bool isShooting = false;
	protected Coroutine shootCoroutine;

	[SerializeField]
	protected Transform hitTarget;

	public bool isMoving
	{
		get 
		{
			return direction.x != 0 || direction.y != 0;
		}
	}

	protected virtual void Start()
	{
		rBody = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	protected virtual void Update () 
	{
		HandleLayers ();
	}

	private void FixedUpdate()
	{
		Movement ();
	}

	public void Movement() 
	{
		try
		{
		rBody.velocity = (direction.normalized * moveSpeed);
		}

		catch 
		{
			Debug.Log ("Error");
		}
	}

	public void HandleLayers()
	{
		if (isMoving) 
		{
			ActivateLayers ("WalkLayer");

			anim.SetFloat ("x", direction.x);
			anim.SetFloat ("y", direction.y);

			StopShooting ();
		}

		else if (isShooting)
		{
			ActivateLayers ("AttackLayer");
		} 

		else 
		{
			ActivateLayers ("IdleLayer");
		}
	}

	public void ActivateLayers(string layerName)
	{
		try
		{
			for (int i = 0; i < anim.layerCount; i++) 
			{
			anim.SetLayerWeight (1, 0);
			}

			anim.SetLayerWeight(anim.GetLayerIndex(layerName), 1);
		}

		catch
		{
			Debug.Log ("Error");
		}
	}

	public void StopShooting()
	{
		if (shootCoroutine != null)
		{
			StopCoroutine (shootCoroutine);
			isShooting = false;
			anim.SetBool ("cast", isShooting);
		}
	}

	public virtual void DeSelect()
	{
	}

	public virtual Transform Select()
	{
		return hitTarget;
	}
}