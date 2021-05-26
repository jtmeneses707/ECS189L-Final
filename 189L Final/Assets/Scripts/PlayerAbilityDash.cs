using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;


// Add cooldown timer for dash to not be abusable
namespace Player.Command
{
    public class PlayerAbilityDash : MonoBehaviour, IPlayerCommand
    {
        [SerializeField]
        private const float DASH_DISTANCE = 3f;
        [SerializeField]
        private const float ACTIVE_TIME = 0.2f;

        // Total time dash has been active.
        private float ElapsedTime;

        // A float that has either a pos or negative 1 value, used to 
        // teleport to the correct side during dash.
        private float DirectionFacing;
        private GameObject Player;
        private Vector2 LastPosition;
        private bool Active;

        void Start()
        {
            this.ElapsedTime = 0f;
            this.Active = false;

        }

        public void Update()
        {
            // Get animator attached to player.
            var animator = this.Player.GetComponent<Animator>();
            if (this.Active)
            {
                this.ElapsedTime += Time.deltaTime;
                if (this.ElapsedTime < ACTIVE_TIME)
                {
                    // animator.SetBool("IsDashing", true);
                    Debug.Log("TRUE");
                    this.Player.transform.position = new Vector2(this.Player.transform.position.x + Time.deltaTime * DirectionFacing * DASH_DISTANCE, this.Player.transform.position.y);
                }
                else
                {
                    // animator.SetBool("IsDashing", false);
                    this.Active = false;
                }
                // Update animator to set isDashing param to current state of ability.
                animator.SetBool("IsDashing", this.Active);
            }
        }


        public void Execute(GameObject gameObject)
        {
            // Resets used if dash ability is currently not active.
            if (!this.Active)
            {
                // Using command pattern, so need to set Player obj to
                // param of Execute. 
                this.Player = gameObject;
                // Sets dash to active now.
                this.Active = true;
                this.ElapsedTime = 0f;

                // Set direction of animation to correct direction.
                this.DirectionFacing = 1f;
                if (gameObject.GetComponent<SpriteRenderer>().flipX == true)
                {
                    this.DirectionFacing = -1f;
                }

            }


        }




        // public void Execute(GameObject gameObject)
        // {



        //     this.Player = gameObject;
        //     var rigidBody = gameObject.GetComponent<Rigidbody2D>();


        //     if (rigidBody != null)
        //     {
        //         // Check for facing in positive direction.
        //         if (gameObject.GetComponent<SpriteRenderer>().flipX == false)

        //             // 1st approach
        //             // Boost the speed of the player
        //             // this.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x * DASH_DISTANCE, rigidBody.velocity.y);

        //             // 2nd approach
        //             // Teleports the player to dodge projectiles
        //             // Combined with animation, it will give off dash effect
        //             this.Player.transform.position = new Vector3(this.Player.transform.position.x + DASH_DISTANCE, this.Player.transform.position.y, 0.0f);

        //         // Otherwise it will be moving in negative direction.
        //         else
        //         {
        //             //this.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x * DASH_DISTANCE, rigidBody.velocity.y);
        //             this.Player.transform.position = new Vector3(this.Player.transform.position.x - DASH_DISTANCE, this.Player.transform.position.y, 0.0f);
        //         } 
        //         Player.GetComponent<Animator>().SetTrigger("IsDashing");
        //     }
        // }

        //void Update()
        //{
        //    LastPosition = 
        //}
    }
}