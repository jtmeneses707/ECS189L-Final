using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;
using Player.Command;

// All Enemies need to be set to EnemyLayer for this class to deal damage against them
namespace Player.Command
{
    public class PlayerAbilityMelee : MonoBehaviour, IPlayerCommand
    {

        public Transform MeleeAttackPoint;
        public float MeleeAttackRange = 0.3f;
        public LayerMask EnemyLayer;
        public float DamageInflicted = 100.0f;
        public float DamageDelay = 0.05f;

        public float AttackRate = 2.0f;
        public float NextAttackTime = 0.0f;
        public bool CanAttack = false;

        // Added to fix console bug
        private Animator animator;
        private GameObject Player;

        private Collider2D[] AllEnemiesHit;
        public int SlimeHitCounter = 0;
        public bool IsSlime = false;

        void Start()
        {
        }

        void Update()
        {

            //Debug.Log(this.AllEnemiesHit[0]);
            if(Time.time >= this.NextAttackTime)
            {
                this.CanAttack = true;
            }
            else
            {
                this.CanAttack = false;
            }

        }

        // Play attack animation
        // Detect all enemies in range of attack
        // Apply damage
        public void Execute(GameObject gameObject)
        {


            // Only melee when can attack is true
            if (this.CanAttack)
            {

                this.Player = gameObject;
                this.animator = this.Player.GetComponent<Animator>();

                //animator.SetBool("IsAttacking", true);
                // Easier way of activating animation.
                // Added trigger to transition state instead of bool.
                this.animator.SetTrigger("IsAttackingTrigger");


                // Detect enemies in attack range (shape of circle)    
                // Note: Must add enemy layer to all enemies and give basicenemy script to all enemies
                this.AllEnemiesHit = Physics2D.OverlapCircleAll(MeleeAttackPoint.position, MeleeAttackRange, EnemyLayer);

                foreach (Collider2D enemy in this.AllEnemiesHit)
                {
                    //Debug.Log("We hit " + enemy.name);

                    if (this.IsSlime)
                    {
                        // Increase Slime Hit Counter
                        this.SlimeHitCounter++;
                    }
                    
                    // Pass deal damage into coroutine to time it with animation
                    //StartCoroutine(DelayForDamage(enemy));

                    // Code to allow enemies to take damage/ decrease HP
                    //enemy.GetComponent<BasicEnemy>().TakeDamage(this.DamageInflicted);

                    enemy.GetComponent<EnemyController>().TakeDamage(this.DamageInflicted);

                }

                // Increment Timer so that we delay when the next attack can be done.
                this.NextAttackTime = Time.time + 1.0f / AttackRate;

            }

            //Debug.Log(Time.time);
            //Debug.Log(NextAttackTime);

        }

        // This is not currently being used!
        // Attempt at Timing attack animation with dealing damage
        //private IEnumerator DelayForDamage(Collider2D enemy)
        //{
        //    yield return new WaitForSeconds(DamageDelay);
        //    enemy.GetComponent<BasicEnemy>().TakeDamage(this.DamageInflicted);
        //}


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
            Gizmos.DrawWireSphere(this.MeleeAttackPoint.position, this.MeleeAttackRange);
        }

    }
}