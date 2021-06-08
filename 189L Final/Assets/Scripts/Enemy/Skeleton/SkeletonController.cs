using System.Collections;
using System.Collections.Generic;
using Enemy.Behavior;
using UnityEngine;

namespace Enemy.Controller
{
    public class SkeletonController : EnemyController
    {
        // Start is called before the first frame update


        // Update is called once per frame
        //void Update()
        //{
        //    FollowPlayerLogic();
        //    AttackPlayerLogic();
        //    RoamOrIdleLogic();
        //}



        //public void AttackPlayerLogic()
        //{
        //    if (IsPlayerNearAttackRadius())
        //    {
        //        AttackPlayer();
        //    }
        //}


        public void RoamOrIdleLogic()
        {
            //Choose randomly between 5-10 seconds on whether to idle or roam
            //Must add a 2d box collider to prevent falling off a cliff
        }

    }
}

