using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class MovePlayerRight : ScriptableObject, IPlayerCommand
    {
        public float Speed = 1.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(this.Speed, rigidBody.velocity.y);
                //gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}

// Use for later after finding audio clip
// FindObjectOfType<AudioManager>().Play("PlayerFootSteps");