using System.Collections;
using System.Collections.Generic;
using Enemy.Behavior;
using UnityEngine;

namespace Enemy
{
    public class SkeletonController : MonoBehaviour, Behavior.EnemyBehavior
    {
        void EnemyBehavior.Attack(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }

        void EnemyBehavior.Death(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }

        void EnemyBehavior.Idle(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }

        void EnemyBehavior.Roam(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }



        // Start is called before the first frame update
        void Start()
        {

        }

        void EnemyBehavior.TakeDamage(GameObject gameObject)
        {
            throw new System.NotImplementedException();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

