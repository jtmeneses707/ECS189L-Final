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
    protected EnemyMovement Move;
    protected float VisibleRadius;
    protected float AttackRadius;
    protected float Health = 100.0f;
    protected float RoamTimer = 0.0f;
    protected GameObject deathAnimation;


    // Start is called before the first frame update
    public void Start()
    {
        Move = new EnemyMovement(EnemyConstants.BasicEnemySpeed, this.gameObject);
        Follow(PlayerObject);

    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void MoveLeft()
    {
        Move.MoveLeft();
    }

    public void MoveRight()
    {
        Move.MoveRight();
    }


    public void Follow(GameObject targetObject)
    {
        float step = EnemyConstants.BasicEnemySpeed * Time.deltaTime;
        Vector2 playerPosition = PlayerObject.transform.position;
        playerPosition.y = transform.position.y;
        transform.position = Vector2.MoveTowards(transform.position, playerPosition, step);
    }

    public void Attack(GameObject targetObject)
    {
        //TODO
        //Play attack animation
        //Subtract damage from player
    }

    public void TakeDamage(float amount)
    {
        Health = Health - amount;
    }

    public void Death()
    {
        Destroy(gameObject);
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
        // followPlayer(PlayerObject);

        // //If player is within Attack Radius
        // EnemyBehavior.Attack(PlayerObject);
    }




    




}
