using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;
using Player.Command;

// All Enemies need to be set to EnemyLayer for this class to deal damage against them
namespace Player.Command
{
    public class PlayerAbilityDownSmash: MonoBehaviour, IPlayerCommand
    {

        public Transform DownSmashPoint;
        public float DownSmashRange = 0.3f;
        public LayerMask EnemyLayer;
        public float DamageInflicted = 150f;
        public float DamageDelay = 0.5f; // delay damage to time with attack animation

        private bool Active;
        private const float ACTIVE_TIME = 0.2f;
        private float ElapsedTime;

        // Added to fix console bug
        private Animator animator;
        private GameObject Player;

        private Collider2D[] AllEnemiesHit;
        public Collider2D DownSmashPointCollider;

        void Start()
        {
            this.ElapsedTime = 0f;
            this.Active = false;
        }

        void Update()
        {
            if (this.Active)
            {
                // Get animator attached to player.
               
                this.ElapsedTime += Time.deltaTime;
                if (this.ElapsedTime < ACTIVE_TIME)
                {
                    //this.Player.transform.position = new Vector2(this.Player.transform.position.x, this.Player.transform.position.y - Time.deltaTime * DirectionFacing * DASH_DISTANCE);
                    this.Active = true;
                }
                else
                {
                    //Debug.Log("Reseting");
                    this.Active = false;
                }
                // Update animator to set isDashing param to current state of ability.
                animator.SetBool("IsDownSmashing", this.Active);
            }

        }

        // Play attack animation
        // Detect all enemies in range of attack
        // Apply damage
        public void Execute(GameObject gameObject)
        {


            // Only melee when can attack is true
            if (!this.Active)
            {
                this.Player = gameObject;
                this.animator = this.Player.GetComponent<Animator>();

                this.Active = true;
                this.ElapsedTime = 0f;

                var contact_filter = new ContactFilter2D();
                contact_filter.useTriggers = false;
                contact_filter.SetLayerMask(EnemyLayer);
                contact_filter.useLayerMask = true;
                var contacts = new Collider2D[10];
                var total_enemies = Physics2D.OverlapCollider(DownSmashPointCollider, contact_filter, contacts);
               
                for (int i = 0; i < total_enemies; i++)
                {
                    Debug.Log("We hit " + contacts[i].name);

                    // Pass deal damage into coroutine to time it with animation
                    StartCoroutine(DelayForDamage(contacts[i]));

                    // Code to allow enemies to take damage/ decrease HP
                    //enemy.GetComponent<EnemyController>().TakeDamage(this.DamageInflicted);
                }

                // Increment Timer so that we delay when the next attack can be done.
                //this.NextAttackTime = Time.time + 1.0f / AttackRate;

            }

            //Debug.Log(this.ElapsedTime);
            //Debug.Log(ACTIVE_TIME);
        }

        private IEnumerator DelayForDamage(Collider2D enemy)
        {
            yield return new WaitForSeconds(DamageDelay);
            enemy.GetComponent<EnemyController>().TakeDamage(this.DamageInflicted);
        }

    }
}