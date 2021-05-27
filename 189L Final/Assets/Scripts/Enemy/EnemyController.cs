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
    protected GameObject PlayerObject;
    protected MovementFactory Move;
    protected float VisibleRadius;
    protected float AttackRadius;

    // Start is called before the first frame update
    void Start()
    {
        Move = new MovementFactory(EnemyConstants.BasicEnemySpeed, this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void EnemyBehavior.Idle()
    {
        //TODO
    }

    void EnemyBehavior.Roam()
    {
        //TODO
    }

    void EnemyBehavior.Follow(GameObject targetObject)
    {
        float step = EnemyConstants.BasicEnemySpeed * Time.deltaTime;
        Vector2 playerPosition = playerObject.transform.position;
        playerPosition.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, step);
    }

    void EnemyBehavior.Attack(GameObject targetObject)
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

    private bool isPlayerNear()
    {
        //TODO
        return true;
    }

    public void AILogic()
    {
        //Choose randomly between 5-10 seconds on whether to idle or roam

        //If player is within Visible Radius
        followPlayer(PlayerObject);

        //If player is within Attack Radius
        EnemyBehavior.Attack(PlayerObject);
    }




    




}
