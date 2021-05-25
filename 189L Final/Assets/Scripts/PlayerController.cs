using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Up;

    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;

    private IPlayerCommand SpaceBar;
    //public float DashCoolDownTime = 2.0f; // 2 second cool down on dash
    //private float NextDashTime = 0.0f;

    private BoxCollider2D Feet;

    // Use later to determine projectile instantiation direction
    private enum Direction {Left, Right};
    private Direction CurrentDirection;

    // Start is called before the first frame update
    void Start()
    {
        this.Right = ScriptableObject.CreateInstance<MovePlayerRight>();
        this.Left = ScriptableObject.CreateInstance<MovePlayerLeft>();
        this.gameObject.AddComponent<MovePlayerUp>();
        this.Up = this.gameObject.GetComponent<MovePlayerUp>();
        this.gameObject.AddComponent<PlayerAbilityDash>();
        this.SpaceBar = this.gameObject.GetComponent<PlayerAbilityDash>();
        this.gameObject.AddComponent<PlayerAbilityShoot>();
        this.Fire2 = this.gameObject.GetComponent<PlayerAbilityShoot>();
        this.Feet = this.gameObject.transform.Find("Feet").GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // To Check for IsGrounded we look through all the contacts that the Player's Feet Box Collider
        // Is in contact with.
        // This resolves the issue of being able to spam jump on the sides of the ground
        var contacts = new Collider2D[32];
        this.Feet.GetContacts(contacts);
        foreach (var col in contacts)
        {
            
            // If the feet is in contact with the ground then we can enable single/ doublejump 
            if (col != null && col.gameObject != null && col.gameObject.tag == "Ground")
            {
                //Debug.Log(col.gameObject.tag);
                //Debug.Log( "Here!");
                this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = true;
                this.gameObject.GetComponent<MovePlayerUp>().CanDoubleJump = true;
            }
            else
            {
                this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = false;
            }
            break;
        }

        //if (Input.GetKey("d"))
        //if (Input.GetKey("a"))
        //var Firepoint = gameObject.transform.Find("FirePoint");

        // Left and right movement
        if (Input.GetAxis("Horizontal") > 0.01)
        {
            this.Right.Execute(this.gameObject);
        }
        if (Input.GetAxis("Horizontal") < -0.01)
        {
            this.Left.Execute(this.gameObject);
        }


        // Needed to change jump inputs to specific keys
        // Using vertical > 0.01 lead to updates that were too fast
        // Using .GetKeyDown instead of .GetKey b/c 
        // it forces the player to have to double click w
        // -.getkeyDown() is called for that specific frame
        if (Input.GetKeyDown("w") || Input.GetKeyDown(KeyCode.UpArrow))
        {
            this.Up.Execute(this.gameObject);
        }


        // Code to be used later: If we want to place cool down on ability
        //if(Time.time > this.NextDashTime)
        //{
        //    if (Input.GetKeyDown("space"))
        //    {
        //        this.SpaceBar.Execute(this.gameObject);
        //        this.NextDashTime = Time.time + this.DashCoolDownTime;
        //    }
        //}

        // Dash/ teleport ability
        if (Input.GetKeyDown("space"))
        {
            this.SpaceBar.Execute(this.gameObject);
        }

        // Shoot Projectile
        if (Input.GetButtonDown("Fire2"))
        {
            this.Fire2.Execute(this.gameObject);
        }


        // Get the animator for the player. 
        var animator = this.gameObject.GetComponent<Animator>();

        // Set params for animator. 
        animator.SetFloat("X-Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x));
        animator.SetFloat("Y-Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y));
        animator.SetBool("IsGrounded", this.gameObject.GetComponent<MovePlayerUp>().IsGrounded);
        animator.SetBool("CanDoubleJump", this.gameObject.GetComponent<MovePlayerUp>().CanDoubleJump);

    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
         
    ////Debug.Log(collision.collider.gameObject);
    //Debug.Log(collision.gameObject);
    //    //collision.collider.name == "groundCheck"

    //    //var ground_checker = collision.GetContacts
    //    // Update IsGrounded whenever ground is touched
    //    // Added condition to make sure that the player's feet needs to touch the ground,
    //    // instead of just any part of the body like before
    //    if (collision.gameObject.tag == "Ground" && this.FeetIsInContactWithGround)
    //    {
    //        this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = true;
    //        this.gameObject.GetComponent<MovePlayerUp>().CanDoubleJump = true;
    //        Debug.Log("Works1");
    //    }
    //}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    // Update Is Grounded whenever player leaves the ground
    //    if (collision.gameObject.tag == "Ground" && this.FeetIsInContactWithGround == false)
    //    {
    //        this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = false;
    //        Debug.Log("Works2");
    //    }
    //}

}
// TO DO: FIX JUMPING CONDITION FOR FEET