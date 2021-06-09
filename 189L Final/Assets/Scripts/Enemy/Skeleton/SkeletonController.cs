using System.Collections;
using System.Collections.Generic;
using Enemy.Behavior;
using UnityEngine;
using Enemy.Constants;

namespace Enemy.Controller
{
    public class SkeletonController : EnemyController
    {
        // Start is called before the first frame update

        protected override void InitStats()
        {
            SetStats(EnemyConstants.SkeletonHealth, EnemyConstants.SkeletonVisibilityRadius, EnemyConstants.SkeletonAttackRadius, EnemyConstants.SkeletonRoamTimer);
        }

    }
}

