using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;


// Add cooldown timer for dash to not be abusable
namespace Player.Command
{
    public class PlayerAbilityDash : MonoBehaviour, IPlayerCommand
    {
        private float DashDistance = 0.5f;
        private GameObject Player;
        private Vector2 LastPosition;

        void Start()
        {
         
        }

        public void Execute(GameObject gameObject)
        {
            this.Player = gameObject;
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();


            if (rigidBody != null)
            {
                // Check for facing in positive direction.
                if (gameObject.GetComponent<SpriteRenderer>().flipX == false)

                    // 1st approach
                    // Boost the speed of the player
                    // this.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x * DashDistance, rigidBody.velocity.y);

                    // 2nd approach
                    // Teleports the player to dodge projectiles
                    // Combined with animation, it will give off dash effect
                    this.Player.transform.position = new Vector3(this.Player.transform.position.x + DashDistance, this.Player.transform.position.y, 0.0f);

                // Otherwise it will be moving in negative direction.
                else
                {
                    //this.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x * DashDistance, rigidBody.velocity.y);
                    this.Player.transform.position = new Vector3(this.Player.transform.position.x - DashDistance, this.Player.transform.position.y, 0.0f);
                } 
                Player.GetComponent<Animator>().SetTrigger("IsDashing");
            }
        }

        //void Update()
        //{
        //    LastPosition = 
        //}
    }
}