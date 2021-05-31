using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject ProjectilePrefab;
    [SerializeField]
    private Transform FirePoint;
    [SerializeField]
    private Transform MeleeAttackPoint;

    [SerializeField]
    private LayerMask EnemyLayer;

    //private AudioManager AudioManager;

    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Up;

    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;

    private IPlayerCommand SpaceBar;
    //public float DashCoolDownTime = 2.0f; // 2 second cool down on dash
    //private float NextDashTime = 0.0f;

    private BoxCollider2D Feet;

    private bool IsFacingRight = true;

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

        this.gameObject.AddComponent<PlayerAbilityMelee>();
        this.Fire1 = this.gameObject.GetComponent<PlayerAbilityMelee>();
        // Pass in Melee Point transform
        this.gameObject.GetComponent<PlayerAbilityMelee>().MeleeAttackPoint = this.MeleeAttackPoint;
        // Pass in Enemy Layer for damage detection
        this.gameObject.GetComponent<PlayerAbilityMelee>().EnemyLayer = this.EnemyLayer;
        
        // Feet used for grounded detection
        this.Feet = this.gameObject.transform.Find("Feet").GetComponent<BoxCollider2D>();

        // Passing ProjectilePrefab to PlayerAbilityShoot
        this.gameObject.GetComponent<PlayerAbilityShoot>().ProjectilePrefab = this.ProjectilePrefab;
        // Fire Point is where the bullet will come out (positioned on the player's hand).
        this.gameObject.GetComponent<PlayerAbilityShoot>().FirePoint = this.FirePoint;
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

        //if((Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") > 0) && this.gameObject.GetComponent<MovePlayerUp>().IsGrounded == true)
        //{
        //    //FindObjectOfType<AudioManager>().Play("PlayerFootSteps");
        //    FindObjectOfType<AudioManager>().Play("PlayerFootSteps");
        //}
        

        // New implementation for flipping player sprite
        // Used for also flipping all child objects attached to player sprite:
        // including FirePoint.
        if (Input.GetAxis("Horizontal") > 0 && !this.IsFacingRight)
        {
            this.IsFacingRight = !this.IsFacingRight;
            
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
        }
        else if(Input.GetAxis("Horizontal") < 0 && this.IsFacingRight)
        {
            this.IsFacingRight = !this.IsFacingRight;
            
            gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
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


        // Dash/ teleport ability
        if (Input.GetKeyDown("space"))
        {
            // Pass in FacingRight since we are no longer using sprite renderer.flipx
            this.gameObject.GetComponent<PlayerAbilityDash>().IsFacingRight = this.IsFacingRight;
            //Debug.Log(this.gameObject.GetComponent<PlayerAbilityDash>().IsFacingRight);
            this.SpaceBar.Execute(this.gameObject);
        }

        // Melee Attack
        if (Input.GetButtonDown("Fire1"))
        {

            this.Fire1.Execute(this.gameObject);
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
        // animator.SetBool("CanDoubleJump", this.gameObject.GetComponent<MovePlayerUp>().CanDoubleJump);
    }

    // This is added as a function event for the ruddadnning animation
    private void FootStep()
    {
        // Ensure that the player is touching the ground
        if(this.gameObject.GetComponent<MovePlayerUp>().IsGrounded == true)
        {
            FindObjectOfType<AudioManager>().Play("PlayerFootSteps");
        }
    }

    private void MeleeSound()
    {
        FindObjectOfType<AudioManager>().Play("MeleeSound");
    }

    private void ShootSound()
    {
        FindObjectOfType<AudioManager>().Play("ShootSound");
    }


    //public void CollisionDetected(ChildCollider collider)
    //{
    //    Debug.Log("child collided");
    //}

    ////private void OnCollisionEnter2D(Collision2D collision)
    ////{

    ////    Collider myCollider = collision.contacts[0].thisCollider;
    ////    Debug.Log(myCollider);

    ////    Debug.Log(this.gameObject.GetComponent<MovePlayerUp>().GetIsGrounded());
    ////    //Debug.Log(collision.collider.gameObject);
    ////    //Debug.Log(collision.gameObject);
    ////    ////collision.collider.name == "groundCheck"

    ////    ////var ground_checker = collision.GetContacts
    ////    //// Update IsGrounded whenever ground is touched
    ////    //// Added condition to make sure that the player's feet needs to touch the ground,
    ////    //// instead of just any part of the body like before
    ////    if (collision.gameObject.tag == "Ground")
    ////    {
    ////        //this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = true;
    ////        //this.gameObject.GetComponent<MovePlayerUp>().CanDoubleJump = true;
    ////        //FindObjectOfType<AudioManager>().Play("PlayerFootSteps");
    ////        Debug.Log("Works1");
    ////    }
    ////}

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    // Update Is Grounded whenever player leaves the ground
    //    if (collision.gameObject.tag == "Ground")
    //    {
    //        FindObjectOfType<AudioManager>().Play("PlayerJumpOffGroundSound");
    //        //this.gameObject.GetComponent<MovePlayerUp>().IsGrounded = false;
    //        Debug.Log("Works2");
    //    }
    //}

}
