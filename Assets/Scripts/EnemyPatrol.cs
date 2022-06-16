using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{

    public Rigidbody2D enemyRB;
    public float patrolSpeed;
    private bool isMovingRight;

    private bool mustTurn;
    public Transform groundCheckRight;
    public Transform groundCheckLeft;
    public LayerMask groundLayer;

    private Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        isMovingRight = true;
    }


    // Fixed Update
    private void FixedUpdate()
    {
        if (isMovingRight && !Physics2D.OverlapCircle(groundCheckRight.position, 0.5f, groundLayer))
        {
            mustTurn = true;
            isMovingRight = false;
        }

        if (!isMovingRight && !Physics2D.OverlapCircle(groundCheckLeft.position, 0.5f, groundLayer))
        {
            mustTurn = false;
            isMovingRight = true;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
        Patrol();

    }


    //Functions
    private void Patrol()
    {
        if (mustTurn)
        {
            moveDirection = new Vector2(patrolSpeed * Time.deltaTime * -1, enemyRB.velocity.y);
            enemyRB.velocity = moveDirection;
        }
        else
        {
            moveDirection = new Vector2(patrolSpeed * Time.deltaTime, enemyRB.velocity.y);
            enemyRB.velocity = moveDirection;
        }
        
    }


}
