using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    Character enemyNPC;

    public float moveSpeed;
    public bool moveRight;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    // Use this for initialization
    void Start()
    {
        enemyNPC = GetComponent<Character>();

    }

    // Update is called once per frame
    void Update()
    {
        enemyNPC.ActivateLayers("WalkLayer");
        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            moveRight = !moveRight;
        }

        if (moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.x);
        }
        else
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.x);
        }

    }
}
