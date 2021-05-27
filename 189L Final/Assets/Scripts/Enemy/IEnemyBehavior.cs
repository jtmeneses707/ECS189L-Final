using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Behavior
{
    public interface EnemyBehavior
    {
        void Idle(GameObject enemyObject);

        void Roam(GameObject enemyObject);

        void Attack(GameObject enemyObject);

        void TakeDamage(GameObject enemyObject);

        void Death(GameObject enemyObject);
    }
}

