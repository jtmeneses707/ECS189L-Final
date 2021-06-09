using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.Controller
{
    public class BossController : MonoBehaviour
    {

        private enum State{
        }

        [SerializeField]
        private float TotalHealth = 200f;

        private float CurrentHealth;

        private bool ActiveDamage; 




        // Update is called once per frame
        void Update()
        {

        }
    }
}

