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
            if (isPlayerNearVisibleRadius())
            {
                Follow(PlayerObject);
            }
        }

        public void AttackPlayerLogic()
        {
            if (isPlayerNearAttackRadius())
            {
                Attack(PlayerObject);
            }
        }


        public void RoamOrIdleLogic()
        {
            //Choose randomly between 5-10 seconds on whether to idle or roam

            //If player is within Visible Radius
            // followPlayer(PlayerObject);

            // //If player is within Attack Radius
            // EnemyBehavior.Attack(PlayerObject);
        }

    }
}

