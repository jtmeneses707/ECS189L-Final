using System.Collections;
using System.Collections.Generic;
using Enemy.Behavior;
using UnityEngine;
using Enemy.Constants;

namespace Enemy.Controller
{
    public class BossController : EnemyController
    {

        // Start is called before the first frame update

        protected override void InitStats()
        {
            SetStats(EnemyConstants.BossHealth, EnemyConstants.BossVisibilityRadius, EnemyConstants.BossAttackRadius, EnemyConstants.BossRoamTimer);
        }

        new public void AttackPlayer()
        {
            Debug.Log("Die!!!! Boss Attack!");
            GameObject hitboxObject = transform.Find("Hitbox").gameObject;
            BoxCollider2D weaponHitBox = hitboxObject.GetComponent<BoxCollider2D>();
            Collider2D playerCollider = PlayerObject.GetComponent<BoxCollider2D>();
            if (weaponHitBox.IsTouching(playerCollider))
            {
                Debug.Log("Touching!!!! Boss Attack!");
                HealthController playerHealthController = playerCollider.GetComponent<HealthController>();
                playerHealthController.TakeDamage();
            }
        }

        /// <Summary>
        /// Used with animation events in animator to 
        /// set when an attack is active. Allows us to 
        /// set a specific, frame accurate window to check if any collisions
        /// occur with player.
        /// </Summary>
        new public void SetAttackActive()
        {
            AttackPlayer();
            this.AttackActive = true;
        }

        new public void SetAttackInactive()
        {
            this.AttackActive = false;
        }


        public void Dash()
        {
            if (this.AttackActive == true)
                return;
            FacePlayer();
            float speed = EnemyConstants.BasicEnemySpeed * Time.fixedDeltaTime * 10;
            Rigidbody2D enemyRigidBody = GetComponent<Rigidbody2D>();
            Vector2 playerPosition = new Vector2(PlayerObject.transform.position.x, PlayerObject.transform.position.y);
            playerPosition.y = transform.position.y;
            Vector2 newPosition = Vector2.MoveTowards(enemyRigidBody.position, playerPosition, speed);

            enemyRigidBody.MovePosition(newPosition);
        }

    }
}

