using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    private Rigidbody2D rBody;

    [SerializeField]
    public float projectileDamage;

    [SerializeField]
    private float speed;
    public Transform target { get; set; }

    // Use this for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            rBody.velocity = direction.normalized * speed;

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }

    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.tag == "HitTarget" && collide.transform == target.transform)
        {
            GetComponent<Animator>().SetTrigger("collide");
            rBody.velocity = Vector2.zero;
            target = null;
            EnemyHealth enemyDamage = collide.gameObject.GetComponentInParent<EnemyHealth>();
            enemyDamage.Damage(projectileDamage);
        }
    }
}