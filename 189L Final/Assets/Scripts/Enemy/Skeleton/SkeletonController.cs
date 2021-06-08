using System.Collections;
using System.Collections.Generic;
using Enemy.Behavior;
using UnityEngine;

namespace Enemy
{
    public class SkeletonController : EnemyController
    {

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            FollowPlayerLogic();
            AttackPlayerLogic();
            RoamOrIdleLogic();
        }

        public void FollowPlayerLogic()
        {
            if (IsPlayerNearVisibleRadius())
            {
                Follow(PlayerObject);
            }
        }

        public void AttackPlayerLogic()
        {
            if (IsPlayerNearAttackRadius())
            {
                Attack(PlayerObject);
            }
        }


        public void RoamOrIdleLogic()
        {
            //Choose randomly between 5-10 seconds on whether to idle or roam
            //Must add a 2d box collider to prevent falling off a cliff
        }

    }
}

