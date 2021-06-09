using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Command;
using Enemy.Constants;

namespace Enemy.Movement
{
    /*
     * Factory class for creating scriptable objects for a game object.
     * MoveLeft() - Moves the character left
     * MoveRight() - Moves the character right
     */
    public class EnemyMovement
    {
        private GameObject CharacterObject;
        private MoveLeftScript MoveLeftCommand;
        private MoveRightScript MoveRightCommand;

        /*
         * EnemyMovement - Constructor method to create a movement controller for a game object.
         * @speed - GameObject movement speed
         * @characterObject - GameObject of the character
         */
        public EnemyMovement(float speed, GameObject characterObject)
        {
            this.CharacterObject = characterObject;
            this.MoveLeftCommand = ScriptableObject.CreateInstance<MoveLeftScript>();
            this.MoveLeftCommand.Init(speed);
            this.MoveRightCommand = ScriptableObject.CreateInstance<MoveRightScript>();
            this.MoveRightCommand.Init(speed);
        }

        public void MoveLeft()
        {
            this.MoveLeftCommand.Execute(CharacterObject);
        }

        public void MoveRight()
        {
            this.MoveRightCommand.Execute(CharacterObject);
        }
    }

    public class MoveLeftScript : ScriptableObject, IEnemyCommand
    {
        private float Speed = 0;

        public void Init(float speed)
        {
            this.Speed = speed;
        }

        public void Execute(GameObject gameObject)
        {
            if (Speed == 0)
            {
                throw new System.Exception("You must call Init to initialize the movement speed. Movement speed cannot be 0.");
            }

            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(-Speed, rigidBody.velocity.y);
            }
        }


    }

    public class MoveRightScript : ScriptableObject, IEnemyCommand
    {
        private float Speed;

        public void Init(float speed)
        {
            this.Speed = speed;
        }

        public void Execute(GameObject gameObject)
        {
            if (Speed == 0)
            {
                throw new System.Exception("You must call Init to initialize the movement speed. Movement speed cannot be 0.");
            }

            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(Speed, rigidBody.velocity.y);
            }
        }
    }
}
