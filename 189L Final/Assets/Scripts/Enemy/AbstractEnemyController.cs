using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Command;
using Enemy.Movement;
using Enemy.Constants;
using Enemy.Behavior;

public class AbstractEnemyController : MonoBehaviour, EnemyBehavior
{
    private MovementFactory Move;

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

    void EnemyBehavior.TakeDamage(GameObject gameObject)
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        Move = new MovementFactory(EnemyConstants.BasicEnemySpeed, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }





}
