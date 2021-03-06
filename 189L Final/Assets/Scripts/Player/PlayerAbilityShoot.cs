using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;


// Damage to Enemy is implemented in the ProjectileController class.
namespace Player.Command
{
    public class PlayerAbilityShoot : MonoBehaviour, IPlayerCommand
    {
        public GameObject ProjectilePrefab;
        // Position where projectile is being launched from
        public Transform FirePoint;
        // Speed of projectile
        public float Speed = 3f;

        public float BulletCreationDelay = 0.2f;

        [SerializeField]
        private const float ACTIVE_TIME = 0.5f;
        private float ElapsedTime;

        // Added to fix console bug
        private Animator animator;
        private GameObject Player;
        private bool Active;

        void Start()
        {
            this.ElapsedTime = 0f;
            this.Active = false;
        }

        void Update()
        {
            if (this.Active)
            {

                this.ElapsedTime += Time.deltaTime;
                if (this.ElapsedTime < ACTIVE_TIME)
                {
    
                }
                else
                {
                    this.Active = false;
                }
                // Update animator
                animator.SetBool("ProjectileCastActive", this.Active);
            }
        }

        public void Execute(GameObject gameObject)
        {

            // Resets used if shoot ability is currently not active.
            if (!this.Active)
            {
                // Using command pattern, so need to set Player obj to
                // param of Execute. 
                this.Player = gameObject;
                this.animator = this.Player.GetComponent<Animator>();

                this.Active = true;
                this.ElapsedTime = 0f;

                // Quaternion.identity - for no rotation. Aligned with the game's 2D axis
                var projectile = (GameObject)Instantiate(ProjectilePrefab, FirePoint.position, Quaternion.identity);

                // Get New instantiate projectiles rigidbody.
                var RB = projectile.GetComponent<Rigidbody2D>();

                // Give it velocity to send it flying.
                RB.velocity = transform.right * Speed;

                // Destroy the prefab after awhile and it hasnt hit anything
                Destroy(projectile, 10.0f);
            }

        }
    }
}
