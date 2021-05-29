using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Behavior
{
    public interface EnemyBehavior
    {
        void MoveLeft();
        void MoveRight();
        void Follow(GameObject targetObject);
        void Attack(GameObject targetObject);
        void TakeDamage(float Amount);
        void Death();
    }
}

