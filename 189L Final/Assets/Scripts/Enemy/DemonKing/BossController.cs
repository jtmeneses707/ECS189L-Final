using System.Collections;
using System.Collections.Generic;
using Enemy.Behavior;
using UnityEngine;
using Enemy.Constants;

namespace Enemy.Controller
{
    public class BossController : EnemyController
    {

        // Start is called before the first frame update

        protected override void InitStats()
        {
            SetStats(EnemyConstants.BossHealth, EnemyConstants.BossVisibilityRadius, EnemyConstants.BossAttackRadius, EnemyConstants.BossRoamTimer);
        }

    }
}

