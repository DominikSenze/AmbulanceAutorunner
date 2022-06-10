using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigidbody;
    private Collider2D myCollider;

    //variables for Ground Check
    public bool grounded;
    public LayerMask IsGround;

    //variables for higher Jump
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    // -------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.IsTouchingLayers(myCollider, IsGround); //grounded is true if player-collider is touching isGround-collider

        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y); //Moving forward

        Jumping();

    }

    private void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //normal Jump when Space or left mouse button pressed
        {
            if (grounded) //Jumping only when player is grounded
            {
                //reseting parameters for higher Jump
                isJumping = true;
                jumpTimeCounter = jumpTime;

                //normal Jump
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
            }
        }

        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0)) //higher Jump when Space or left mouse button longer pressed
        {
            if (isJumping) //higher Jump only while already jumping
            {
                if (jumpTimeCounter > 0) //Timer so that Player can't jump unendlessly high
                {
                    myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) //no more higher jumping when releasing key
        {
            isJumping = false;
        }
    }
}
