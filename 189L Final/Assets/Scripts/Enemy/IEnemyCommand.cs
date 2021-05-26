using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Command
{
    public interface IEnemyCommand
    {
        void Execute(GameObject gameObject);
    }
}
