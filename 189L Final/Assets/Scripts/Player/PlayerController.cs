using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Command;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject IsAlive;

    [SerializeField]
    private GameObject ProjectilePrefab;
    [SerializeField]
    private Transform FirePoint;
    [SerializeField]
    private Transform MeleeAttackPoint;
    [SerializeField]
    private Transform DownSmashPoint;

    [SerializeField]
    private Collider2D DownSmashPointCollider;

    [SerializeField]
    private LayerMask EnemyLayer;

    // ** Changeable values for game tuning ** // 
    [SerializeField]
    private float JumpSpeed = 2.0f; // to be passed into MovePlayerUp, determines how high we jump
    [SerializeField]
    private float MeleeAttackRange = 0.3f;
    [SerializeField]
    private float DownSmashRange = 2.0f;
    //[SerializeField]
    //private float PlayerMovementSpeed = 2.0f;
    // **   *******  *******  *******    ** // 

    [SerializeField]
    private GameObject TransformEffectPoint;

    private HealthController HealthController;

    //private AudioManager AudioManager;

    private IPlayerCommand Right;
    private IPlayerCommand Left;
    private IPlayerCommand Up;
    private IPlayerCommand Down;

    private IPlayerCommand Fire1;
    private IPlayerCommand Fire2;

    private IPlayerCommand SpaceBar;
    //public float DashCoolDownTime = 2.0f; // 2 second cool down on dash
    //private float NextDashTime = 0.0f;

    private BoxCollider2D Feet;

    private bool IsFacingRight = true;
    private bool RestrictMovement = false;
    private bool IsSlime = false;
    private int SlimeHitCounter = 0;
    private Animator animator;

    void OnCollisionEnter2D(Collision2D collision)
        {   
            // Grab the name and compare the name to all of the potential collisions
            var collider = collision.gameObject.name;

            // Water collision, should result in death and defeat screen
            if (collider == "WaterHitbox")
            {
                FindObjectOfType<AudioManager>().Play("WaterSplash");
                Debug.Log("Death by water");
                Destroy(IsAlive);
            }
            // Fire collison, should result in taking damage or ignoring the collision if player dashed
            var dashCommand = this.gameObject.GetComponent<PlayerAbilityDash>();
            if (collider == "Fire") 
            {
                // Ignore collision if player successfully dashed through the fire
                if (dashCommand.Active == true) 
                {
                    var fireCollider = collision.gameObject.GetComponent<BoxCollider2D>();
                    var ourCollider = this.GetComponent<BoxCollider2D>();
                    Physics2D.IgnoreCollision(fireCollider, ourCollider, true);
                }
                // Take damage if player failed to utilize dash to bypass the fire
                else 
                {
                    Debug.Log("We lost one heart by burning!");
                    FindObjectOfType<AudioManager>().Play("FireBurn");
                    this.HealthController.TakeDamage();
                }
                // Checking health
                Debug.Log(this.HealthController.GetHearts());
            }

            // Cannot do detection for enemy attacks this way. Will always trigger if we enter
            // the trigger collider, even if not during an attack.
            // else{
            //     Debug.Log("Did not collide?");
            // }
        }
    // Start is called before the first frame update
    void Start()
    {
        // Get the animator for the player. 
        this.animator = this.gameObject.GetComponent<Animator>();

        this.Right = ScriptableObject.CreateInstance<MovePlayerRight>();
        this.Left = ScriptableObject.CreateInstance<MovePlayerLeft>();
        this.gameObject.AddComponent<MovePlayerUp>();
        this.Up = this.gameObject.GetComponent<MovePlayerUp>();

        this.gameObject.AddComponent<PlayerAbilityDash>();
        this.SpaceBar = this.gameObject.GetComponent<PlayerAbilityDash>();
        this.gameObject.AddComponent<PlayerAbilityShoot>();
        this.Fire2 = this.gameObject.GetComponent<PlayerAbilityShoot>();

        this.gameObject.AddComponent<PlayerAbilityDownSmash>();
        this.Down = this.gameObject.GetComponent<PlayerAbilityDownSmash>();
        // Pass in Melee Point transform
        this.gameObject.GetComponent<PlayerAbilityDownSmash>().DownSmashPoint = this.DownSmashPoint;
        // Pass in collider for hit box
        this.gameObject.GetComponent<PlayerAbilityDownSmash>().DownSmashPointCollider = this.DownSmashPointCollider;
        // Pass in Enemy Layer for damage detection
        this.gameObject.GetComponent<PlayerAbilityDownSmash>().EnemyLayer = this.EnemyLayer;

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

        this.HealthController = this.gameObject.GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // ***Adjust this values for game feel as needed*** // 
        this.gameObject.GetComponent<MovePlayerUp>().JumpSpeed = this.JumpSpeed;
        this.gameObject.GetComponent<PlayerAbilityMelee>().MeleeAttackRange = this.MeleeAttackRange;
        this.gameObject.GetComponent<PlayerAbilityDownSmash>().DownSmashRange = this.DownSmashRange;

        //this.Left.ChangeSpeed(this.PlayerMovementSpeed);

        //this.Left.Speed = this.PlayerMovementSpeed;
        //this.gameObject.GetComponent<MovePlayerRight>().Speed = this.PlayerMovementSpeed;
        // ***************            ***************** //


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
        
        if(RestrictMovement == false) 
        {
            // Left and right movement
            if (Input.GetAxis("Horizontal") > 0.01)
            {
                this.Right.Execute(this.gameObject);

            }
            if (Input.GetAxis("Horizontal") < -0.01)
            {
                this.Left.Execute(this.gameObject);
            }

            // New implementation for flipping player sprite
            // Used for also flipping all child objects attached to player sprite:
            // including FirePoint.
            if (Input.GetAxis("Horizontal") > 0 && !this.IsFacingRight)
            {
                this.IsFacingRight = !this.IsFacingRight;

                gameObject.transform.Rotate(0.0f, 180.0f, 0.0f);
            }
            else if (Input.GetAxis("Horizontal") < 0 && this.IsFacingRight)
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

            // Melee Attack
            if (Input.GetButtonDown("Fire1"))
            {

                this.Fire1.Execute(this.gameObject);
            }

            // Can only do these special moves when not in slime mode
            if(IsSlime == false)
            {
                // Dash/ teleport ability
                if (Input.GetKeyDown("space"))
                {
                    // Pass in FacingRight since we are no longer using sprite renderer.flipx
                    this.gameObject.GetComponent<PlayerAbilityDash>().IsFacingRight = this.IsFacingRight;
                    //Debug.Log(this.gameObject.GetComponent<PlayerAbilityDash>().IsFacingRight);
                    this.SpaceBar.Execute(this.gameObject);
                }

                // Shoot Projectile
                if (Input.GetButtonDown("Fire2"))
                {

                    this.Fire2.Execute(this.gameObject);
                }

                //Down Smash Ability
                if (Input.GetKeyDown("s") || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    if (this.gameObject.GetComponent<MovePlayerUp>().IsGrounded)
                    {
                        this.Down.Execute(this.gameObject);
                    }
                }
            }        
        }      

        // Set params for animator. 
        animator.SetFloat("X-Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x));
        animator.SetFloat("Y-Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.y));
        animator.SetBool("IsGrounded", this.gameObject.GetComponent<MovePlayerUp>().IsGrounded);

        this.gameObject.GetComponent<PlayerAbilityMelee>().IsSlime = this.IsSlime;

        // Condition for Changing into Slime
        if (this.HealthController.GetHearts() == 1 && this.IsSlime == false)
        {
            this.IsSlime = true;
            Debug.Log("Here!");
            //this.animator.SetTrigger("IsDeadTrigger");
            //animator.SetBool("IsDead", true);
            TransformEffectPoint.active = true;
            StartCoroutine(DelayTransformation(0));
        }

        // Change back into OG form once enough damage is done
        else if (this.gameObject.GetComponent<PlayerAbilityMelee>().SlimeHitCounter == 2 && this.IsSlime == true)
        {
            //Debug.Log("Hello!");

            //this.IsSlime = false;
            //this.HealthController.ResetForm();
            //this.gameObject.GetComponent<PlayerAbilityMelee>().SlimeHitCounter = 0; // reset counter

            TransformEffectPoint.active = true;
            StartCoroutine(DelayTransformation(1));
        }


        //Debug.Log(this.gameObject.GetComponent<PlayerAbilityMelee>().SlimeHitCounter);
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

    //// Add to the animation event frame to transform to slime
    //private void AnimationEventTransform()
    //{
    //    animator.SetBool("IsDead", false);
    //}

    //// Add to the animation event frame to transform back from slime
    //private void AnimationEventTransformBack()
    //{
    //    animator.SetBool("IsSlimeDead", false);
    //}

    private IEnumerator DelayTransformation(int temp)
    {
        yield return new WaitForSeconds(0.3f);
        TransformEffectPoint.active = false;
        // animator.SetBool("IsDead", false);
        if (temp == 0)
        {
            animator.SetLayerWeight(0, 0);
            animator.SetLayerWeight(1, 1);
            this.IsSlime = true;
        }
        else
        {
            this.IsSlime = false;
            this.HealthController.ResetForm();
            this.gameObject.GetComponent<PlayerAbilityMelee>().SlimeHitCounter = 0;
        }
    }

    // Allow the player to move again after using DownSmashAbility
    private void RestrictPlayerMovement()
    {
        RestrictMovement = true;
    }

    // During the DownSmash the player can't move/ use abilities
    private void UnRestrictPlayerMovement()
    {
        RestrictMovement = false;
    }


    private void MeleeSound()
    {
        FindObjectOfType<AudioManager>().Play("MeleeSound");
    }

    private void ShootSound()
    {
        FindObjectOfType<AudioManager>().Play("ShootSound");
    }

    private void DownSmashSound()
    {
        FindObjectOfType<AudioManager>().Play("DownSmashSound");
    }

    // For Passing through enemies
    private void GhostModeOff()
    {
        //Debug.Log("Ended!");
        this.gameObject.layer = LayerMask.NameToLayer("Characters");
    }

    //public void SetAllCollidersStatus(bool active)
    //{
    //    foreach (Collider c in GetComponents<Collider>())
    //    {
    //        c.enabled = active;
    //    }
    //}


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
