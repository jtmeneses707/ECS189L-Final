using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerUp: MonoBehaviour, IPlayerCommand
    {
        public float JumpSpeed = 2.0f;
        private GameObject Jumper;
        public bool IsGrounded;

        public bool CanDoubleJump;
        //public bool this.Active;
        public bool IsDoubleJump;
        void Start()
        {
            this.IsGrounded = true;
            this.CanDoubleJump = false;
        }

        public void Execute(GameObject gameObject)
        {
            this.Jumper = gameObject;
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (this.IsGrounded == true)
            {
                this.Jumper.GetComponent<Rigidbody2D>().velocity = Vector2.up * this.JumpSpeed;
                this.CanDoubleJump = true;

                FindObjectOfType<AudioManager>().Play("PlayerJumpOffGroundSound");
                //Debug.Log(this.DoubleJump);
                //Debug.Log("we are here 1");
            }
            else if (this.CanDoubleJump == true && this.IsGrounded == false)
            {
                //Debug.Log("we are here 2");
                //this.Jumper.GetComponent<Rigidbody2D>().velocity = Vector2.up * Speed;
                this.Jumper.GetComponent<Rigidbody2D>().velocity = new Vector2(rigidBody.velocity.x, this.JumpSpeed * 1.5f);
                this.CanDoubleJump = false;
            }

            //Debug.Log(this.IsGrounded);
        }

        public bool GetIsGrounded()
        {
            return this.IsGrounded;
        }


    }
}