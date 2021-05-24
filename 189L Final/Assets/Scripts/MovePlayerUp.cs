using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerUp: MonoBehaviour, IPlayerCommand
    {
        private float Speed = 2.0f;
        private GameObject Jumper;
        public bool IsGrounded;

        public bool CanDoubleJump;
        //public bool this.Active;

        void Start()
        {
            this.IsGrounded = false;
            this.CanDoubleJump = false;
        }

        public void Execute(GameObject gameObject)
        {
            this.Jumper = gameObject;
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (this.IsGrounded == true)
            {
                this.Jumper.GetComponent<Rigidbody2D>().velocity = Vector2.up * Speed;
                this.CanDoubleJump = true;
                //Debug.Log(this.DoubleJump);
            }
            else if (this.CanDoubleJump == true && this.IsGrounded == false)
            {
                //Debug.Log("we are here");
                //this.Jumper.GetComponent<Rigidbody2D>().velocity = Vector2.up * Speed;
                this.Jumper.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x, this.Speed*2);
                this.CanDoubleJump = false;
            }

            
        }

        //void Update()
        //{
        //    // Ensure that object is set before animation is performed
        //    if (this.Active)
        //    {
        //        if (this.IsGrounded == false)
        //        {
        //            // start animation
                   
        //        }

        //        if (this.IsGrounded == true)
        //        {
        //            // Stop the animation
                    
        //        }
        //    }
        //}

    }
}