using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerLeft : ScriptableObject, IPlayerCommand
    {
        public float Speed = 2.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(-this.Speed, rigidBody.velocity.y);
                //gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        public void ChangeSpeed(float newSpeed)
        {
            this.Speed = newSpeed;
        }
    }
}