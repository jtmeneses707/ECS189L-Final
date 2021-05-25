using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerAbilityDash : MonoBehaviour, IPlayerCommand
    {
        private float Speed = 3.0f;
        private GameObject Player;
        void Start()
        {
         
        }

        public void Execute(GameObject gameObject)
        {
            this.Player = gameObject;
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                // Check for facing in positve direction.
                if(gameObject.GetComponent<SpriteRenderer>().flipX == false)
                    this.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x + Speed, rigidBody.velocity.y);

                // Otherwise it will be moving in negative direction.
                else
                {
                    this.Player.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x - Speed, rigidBody.velocity.y);
                }
            }
        }
    }
}