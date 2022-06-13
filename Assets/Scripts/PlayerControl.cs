using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    //private Collider2D myCollider;

    public float moveSpeed;
    private float moveSpeedStore;
    public float jumpForce;

    //variables for higher Jump
    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    private bool canDoubleJump;

    //viables for increasing speed
    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
        
    //variables for Ground Check
    public bool grounded;
    public LayerMask IsGround;
    public Transform groundCheck;
    public float groundCheckRadius;
    

    //reference for GameManager Script
    public GameManager theGameManager;

    

    // -------------------------------------------------------------------------------
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, IsGround);
        
        //speed increasing when player reaches Milestone
        if(transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;
            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier; //increasing distance of Milestones
            moveSpeed = moveSpeed * speedMultiplier; //increasing movement speed
        }

        //moving & jumping
        myRigidbody.velocity = new Vector2(moveSpeed, myRigidbody.velocity.y);
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

                canDoubleJump = true;
            }

            //for double jump
            if (!grounded && canDoubleJump)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
                jumpTimeCounter = jumpTime;
                isJumping = false;
                canDoubleJump = false;
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


    //Game Over when collision
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killer")
        {
            theGameManager.RestartGame();
            moveSpeed = moveSpeedStore; //reseting movement speed
            speedMilestoneCount = speedMilestoneCountStore; //reseting milestones
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }  

        
    }
}
