using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Command
{
    public interface IPlayerCommand
    {
        void Execute(GameObject gameObject);
    }
}
