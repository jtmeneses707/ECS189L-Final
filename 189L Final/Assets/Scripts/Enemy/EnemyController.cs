using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Command;
using Enemy.Movement;
using Enemy.Constants;
using Enemy.Behavior;

public class EnemyController : MonoBehaviour, EnemyBehavior
{
    [SerializeField]
    private GameObject PlayerObject;
    private MovementFactory Move;

    void EnemyBehavior.Idle()
    {
        //TODO
    }

    void EnemyBehavior.Roam()
    {
        //TODO
    }

    void EnemyBehavior.Attack(GameObject enemyObject)
    {
        //TODO
    }

    void EnemyBehavior.TakeDamage()
    {
        //TODO
    }

    void EnemyBehavior.Death()
    {
        //TODO
    }

    // Start is called before the first frame update
    void Start()
    {
        Move = new MovementFactory(EnemyConstants.BasicEnemySpeed, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer(PlayerObject);
    }



    private bool isPlayerNear()
    {
        //TODO
        return true;
    }

    private void followPlayer(GameObject playerObject)
    {
        float step = EnemyConstants.BasicEnemySpeed * Time.deltaTime;
        Vector2 playerPosition = playerObject.transform.position;
        playerPosition.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, step);
    }

    private void attackPlayer(GameObject playerObject)
    {

    }






}
