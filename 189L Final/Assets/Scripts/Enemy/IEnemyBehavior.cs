using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Behavior
{
    public interface EnemyBehavior
    {
        void MoveLeft();
        void MoveRight();
        void FollowPlayer();
        void AttackPlayer();
        void TakeDamage(float Amount);
        void Die();
    }
}

