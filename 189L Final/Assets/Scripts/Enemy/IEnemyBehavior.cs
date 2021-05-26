using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Behavior
{
    public interface EnemyBehavior
    {
        void Idle(GameObject gameObject);

        void Roam(GameObject gameObject);

        void Attack(GameObject gameObject);

        void TakeDamage(GameObject gameObject);

        void Death(GameObject gameObject);
    }
}

