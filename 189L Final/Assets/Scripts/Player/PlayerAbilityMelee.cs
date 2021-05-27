using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerAbilityMelee : MonoBehaviour, IPlayerCommand
    {

        public Transform MeleeAttackPoint;
        public float AttackRange = 0.3f;
        public LayerMask EnemyLayer;
        public int DamageInflicted = 1;
        public float DamageDelay = 0.05f;

        [SerializeField]
        private const float ACTIVE_TIME = 0.2f;
        private float ElapsedTime;

        // Added to fix console bug
        private Animator animator;
        private GameObject Player;
        private bool Active;

        private Collider2D[] AllEnemiesHit;

        void Start()
        {
            this.ElapsedTime = 0f;
            this.Active = false;
        }

        void Update()
        {

            //Debug.Log(this.AllEnemiesHit[0]);

            //if (this.Active)
            //{

            //    this.ElapsedTime += Time.deltaTime;
            //    if (this.ElapsedTime < ACTIVE_TIME)
            //    {

            //    }
            //    else
            //    {
            //        this.Active = false;
            //    }
            //    // Update animator
            //    animator.SetBool("IsAttacking", this.Active);
            //}

        }

        // Play attack animation
        // Detect all enemies in range of attack
        // Apply damage
        public void Execute(GameObject gameObject)
        {

            this.Player = gameObject;
            this.animator = this.Player.GetComponent<Animator>();

            //animator.SetBool("IsAttacking", true);
            // Easier way of activating animation.
            // Added trigger to transition state instead of bool.
            this.animator.SetTrigger("IsAttackingTrigger");

            this.Active = true;
            this.ElapsedTime = 0f;

            // Detect enemies in attack range (shape of circle)    
            // Note: Must add enemy layer to all enemies and give basicenemy script to all enemies
            this.AllEnemiesHit = Physics2D.OverlapCircleAll(MeleeAttackPoint.position, AttackRange, EnemyLayer);

            foreach (Collider2D enemy in this.AllEnemiesHit)
            {
                Debug.Log("We hit " + enemy.name);
               
                // Pass deal damage into coroutine to time it with animation
                //StartCoroutine(DelayForDamage(enemy));

                // Code to allow enemies to take damage/ decrease HP
                enemy.GetComponent<BasicEnemy>().TakeDamage(this.DamageInflicted);
            }
        }

        // Attempt at Timing attack animation with dealing damage
        private IEnumerator DelayForDamage(Collider2D enemy)
        {
            yield return new WaitForSeconds(DamageDelay);
            enemy.GetComponent<BasicEnemy>().TakeDamage(this.DamageInflicted);
        }


        // Note Gizmos only called when the Player object is selected in the scene!
        void OnDrawGizmosSelected()
        {
            //Debug.Log("Gizmos!");

            if (MeleeAttackPoint == null)
            {
                return;
            }
            Gizmos.color = Color.red;

            // Draws the sphere so that we know how much to adjust melee aoe
            Gizmos.DrawWireSphere(this.MeleeAttackPoint.position, this.AttackRange);
        }

    }
}