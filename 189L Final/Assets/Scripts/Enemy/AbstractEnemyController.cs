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

    void EnemyBehavior.Idle(GameObject enemyObject)
    {
        throw new System.NotImplementedException();
    }

    void EnemyBehavior.Roam(GameObject enemyObject)
    {
        throw new System.NotImplementedException();
    }

    void EnemyBehavior.Attack(GameObject enemyObject)
    {
        throw new System.NotImplementedException();
    }

    void EnemyBehavior.TakeDamage(GameObject enemyObject)
    {
        throw new System.NotImplementedException();
    }

    void EnemyBehavior.Death(GameObject enemyObject)
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



    private bool isPlayerNear()
    {

    }

    private void followPlayer(GameObject playerObject)
    {

    }

    private void attackPlayer(GameObject playerObject)
    {

    }






}
