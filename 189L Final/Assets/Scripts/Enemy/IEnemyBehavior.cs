using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Behavior
{
    public interface EnemyBehavior
    {
        void Idle();
        void Roam();
        void Follow(GameObject targetObject);
        void Attack(GameObject targetObject);
        void TakeDamage();
        void Death();
    }
}

