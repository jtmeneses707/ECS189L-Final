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
            Collider2D weaponHitBox = GetComponentInChildren<BoxCollider2D>();
            Collider2D playerCollider = PlayerObject.GetComponent<BoxCollider2D>();
            if (weaponHitBox.IsTouching(playerCollider))
            {
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

    }
}

