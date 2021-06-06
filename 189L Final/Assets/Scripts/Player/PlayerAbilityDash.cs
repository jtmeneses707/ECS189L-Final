using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;


// Add cooldown timer for dash to not be abusable
namespace Player.Command
{
    public class PlayerAbilityDash : MonoBehaviour, IPlayerCommand
    {
        private const float DASH_DISTANCE = 2.5f;
        private const float ACTIVE_TIME = 0.3f;

        // Total time dash has been active.
        private float ElapsedTime;

        // A float that has either a pos or negative 1 value, used to 
        // teleport to the correct side during dash.
        private float DirectionFacing;
        private GameObject Player;
        private bool Active;
        public bool IsFacingRight;

        // Added to fix console bug
        private Animator animator;

        void Start()
        {
            this.ElapsedTime = 0f;
            this.Active = false;
            this.IsFacingRight = true;
            this.DirectionFacing = 1f;
        }

        public void Update()
        {
            // Get animator attached to player.
   
            if (this.Active)
            {
                // Get animator attached to player.
                var animator = this.Player.GetComponent<Animator>();
                this.ElapsedTime += Time.deltaTime;
                if (this.ElapsedTime < ACTIVE_TIME)
                {
                    this.Player.transform.position = new Vector2(this.Player.transform.position.x + Time.deltaTime * DirectionFacing * DASH_DISTANCE, this.Player.transform.position.y);
                }
                else
                {
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
                this.animator = this.Player.GetComponent<Animator>();

                // Sets dash to active now.
                this.Active = true;
                this.ElapsedTime = 0f;

                // Set direction of animation to correct direction.
                //this.DirectionFacing = 1f;
                //Debug.Log(this.IsFacingRight);

                if (!this.IsFacingRight)
                {
                    this.DirectionFacing = -1f;
                }
                else
                {
                    this.DirectionFacing = 1f;
                }

                this.gameObject.layer = LayerMask.NameToLayer("PlayerGhost");

                //Debug.Log(this.gameObject.layer);


            }
            //Debug.Log(this.DirectionFacing);

        }

    }
}