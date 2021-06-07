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
    public float Health = 100.0f;
    protected float RoamTimer = 0.0f;
    protected GameObject deathAnimation;

    // Materials for indicating enemy damage
    private Material MatWhite;
    private Material MatDefault;
    SpriteRenderer SR;



    // Start is called before the first frame update
    public void Start()
    {
        this.SR = GetComponent<SpriteRenderer>();
        // By default Ressources.Load returns an object, but here we want a material.
        this.MatWhite = Resources.Load("Materials/WhiteFlash", typeof(Material)) as Material;
        this.MatDefault = this.SR.material;

        Move = new EnemyMovement(EnemyConstants.BasicEnemySpeed, this.gameObject);
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
        Debug.Log(amount);

        Health = Health - amount;
        this.SR.material = this.MatWhite;
        Debug.Log(Health);

        if (Health <= 0)
        {
            Death();
        }
        else
        {
            Invoke("ResetMaterial", 0.1f);
        }

    }

    void ResetMaterial()
    {
        SR.material = this.MatDefault;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public bool isPlayerNearVisibleRadius()
    {
        float playerDistance = (PlayerObject.transform.position - transform.position).magnitude;
        return playerDistance < VisibleRadius;
    }

    public bool isPlayerNearAttackRadius()
    {
        float playerDistance = (PlayerObject.transform.position - transform.position).magnitude;
        return playerDistance < AttackRadius;
    }






    




}
