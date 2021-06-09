using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Command;
using Enemy.Movement;
using Enemy.Constants;
using Enemy.Behavior;

namespace Enemy.Controller
{
    public abstract class EnemyController : MonoBehaviour, EnemyBehavior
    {
        public Animator animator;

        [SerializeField]
        protected GameObject PlayerObject;

        protected float Health;
        protected float VisibilityRadius;
        protected float AttackRadius;
        protected float RoamTimer;

        protected bool AttackActive;

        protected bool isTransformFlipped = false;
        protected EnemyMovement Move;

        // Materials for indicating enemy damage
        private Material MatWhite;
        private Material MatDefault;
        SpriteRenderer SR;



        // Start is called before the first frame update
        public void Start()
        {
            Init();
            Collider2D playerCollider = PlayerObject.GetComponent<BoxCollider2D>();
            Collider2D enemyCollider = GetComponent<BoxCollider2D>();
            Physics2D.IgnoreCollision(playerCollider, enemyCollider);
        }

        protected void Init()
        {
            InitStats();
            this.SR = GetComponent<SpriteRenderer>();
            // By default Ressources.Load returns an object, but here we want a material.
            this.MatWhite = Resources.Load("Materials/WhiteFlash", typeof(Material)) as Material;
            this.MatDefault = this.SR.material;
            this.AttackActive = false;

            Move = new EnemyMovement(EnemyConstants.BasicEnemySpeed, this.gameObject);
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            // Grab the name and compare the name to all of the potential collisions
            var collider = collision.gameObject.name;

            // Water collision, should result in death and defeat screen
            if (collider == "WaterHitbox")
            {
                Debug.Log("Death by water");
                Die();
            }
        }

        protected abstract void InitStats();

        protected void SetStats(float health, float visibilityRadius, float attackRadius, float roamTimer)
        {
            Health = health;
            VisibilityRadius = visibilityRadius;
            AttackRadius = attackRadius;
            RoamTimer = roamTimer;
        }

        public void MoveLeft()
        {
            Move.MoveLeft();
        }

        public void MoveRight()
        {
            Move.MoveRight();
        }

        public void FollowPlayer()
        {
            FacePlayer();
            float speed = EnemyConstants.BasicEnemySpeed * Time.fixedDeltaTime;
            Rigidbody2D enemyRigidBody = GetComponent<Rigidbody2D>();
            Vector2 playerPosition = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
            playerPosition.y = transform.position.y;
            Vector2 newPosition = Vector2.MoveTowards(enemyRigidBody.position, playerPosition, speed);

            enemyRigidBody.MovePosition(newPosition);
        }

        public void AttackPlayer()
        {
            PolygonCollider2D weaponHitBox = GetComponentInChildren<PolygonCollider2D>();
            Collider2D playerCollider = PlayerObject.GetComponent<BoxCollider2D>();
            if (weaponHitBox.IsTouching(playerCollider))
            {
                HealthController playerHealthController = playerCollider.GetComponent<HealthController>();
                playerHealthController.TakeDamage();
            }
        }

        public void TakeDamage(float amount)
        {

            if (this.gameObject.tag == "SkeletonEnemy")
            {
                FindObjectOfType<AudioManager>().Play("SkeletonDamageSound");
            }
            else if (this.gameObject.tag == "DemonKing")
            {
                FindObjectOfType<AudioManager>().Play("BossDamageSound");
            }

            Debug.Log(amount);

            Health = Health - amount;
            this.SR.material = this.MatWhite;
            Debug.Log(Health);

            if (Health <= 0)
            {
                Die();
                Debug.Log("Dead");
            }
            else
            {
                Invoke("ResetMaterial", 0.1f);
            }

        }

        public void Die()
        {
            Debug.Log("Skeleton Dead!");


            //Disable Enemy
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;

            //Play Die Animation
            animator.SetBool("IsDead", true);
            //Destroy(gameObject);
        }

        void ResetMaterial()
        {
            SR.material = this.MatDefault;
        }

        public void FacePlayer()
        {
            if (transform.position.x > PlayerObject.transform.position.x && !isTransformFlipped)
            {
                FlipEnemyTransform();
            }
            else if (transform.position.x < PlayerObject.transform.position.x && isTransformFlipped)
            {
                FlipEnemyTransform();
            }
        }

        public void FlipEnemyTransform()
        {
            Vector3 transformScale = transform.localScale;
            transformScale.z = transformScale.z * -1;

            transform.localScale = transformScale;
            transform.Rotate(0f, 180f, 0f);
            isTransformFlipped = !isTransformFlipped;
        }

        public bool IsPlayerNearVisibleRadius()
        {
            float playerDistance = (PlayerObject.transform.position - transform.position).magnitude;
            return playerDistance < VisibilityRadius;
        }

        public bool IsPlayerNearAttackRadius()
        {
            float playerDistance = (PlayerObject.transform.position - transform.position).magnitude;
            return playerDistance < AttackRadius;
        }

        public void SeekPlayerStateLogic()
        {
            if (IsPlayerNearVisibleRadius())
            {
                animator.SetBool("InRangeOfPlayer", true);
            }
            else
            {
                animator.SetBool("InRangeOfPlayer", false);
            }
        }

        public void AttackPlayerStateLogic()
        {
            if (IsPlayerNearAttackRadius())
            {
                animator.SetTrigger("Attack");
            }
        }


        /// <Summary>
        /// Used with animation events in animator to 
        /// set when an attack is active. Allows us to 
        /// set a specific, frame accurate window to check if any collisions
        /// occur with player.
        /// </Summary>
        public void SetAttackActive()
        {
            AttackPlayer();
            this.AttackActive = true;
        }

        public void SetAttackInactive()
        {
            this.AttackActive = false;
        }








    }
}