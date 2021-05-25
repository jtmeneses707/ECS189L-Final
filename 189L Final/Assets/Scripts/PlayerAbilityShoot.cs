using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;

namespace Player.Command
{
    public class PlayerAbilityShoot : MonoBehaviour, IPlayerCommand
    {

        void Start()
        {

        }

        public void Execute(GameObject gameObject)
        {
            // instantiate projectile, destroy if it hits something

            // Also need to recalibrate the firepoint direction so that it flips when the player moves 
            // in the oppositive direction
            //var Firepoint = gameObject.transform.Find("FirePoint");
            //Debug.Log(Firepoint);


        }


    }
}