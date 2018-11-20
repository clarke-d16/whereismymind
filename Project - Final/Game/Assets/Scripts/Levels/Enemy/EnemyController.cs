using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character {

    [SerializeField]
    private CanvasGroup healthGroup;

    [SerializeField]
	private Transform target;

	public Transform Target
	{
		get 
		{
			return target;
		}

		set
		{
			target = value;
		}
	}

	protected override void Update()
	{
			Chase ();
			base.Update ();
	}

	private void Chase()
	{
		if (target != null) {
			direction = (target.transform.position - transform.position).normalized;
			transform.position = Vector2.MoveTowards (transform.position, target.position, moveSpeed * Time.deltaTime);
		} 
		else
		{
			direction = Vector2.zero;
		}
	}

	public override Transform Select()
	{
        healthGroup.alpha = 1;
		return base.Select ();
	}

	public override void DeSelect ()
	{
        healthGroup.alpha = 0;
        base.DeSelect ();
	}

}