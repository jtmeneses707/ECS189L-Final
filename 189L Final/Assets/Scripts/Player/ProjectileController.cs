using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enemy.Controller;

public class ProjectileController : MonoBehaviour
{
    // Need to change these in the prefab in projectiles folder, for the numbers to actually change
    public float Speed = 10.0f;
    public float Damage = 50.0f;
    public Rigidbody2D RB;

    // Start is called before the first frame update
    public GameObject Player;

    void Start()
    {
        //RB.velocity = transform.right * Speed;
    }

    void Update()
    {
        // Rotate the projectile to make it more dynamic
        this.transform.Rotate(0, 0, 200 * Time.deltaTime);
    }

    // Whenever projectile hits something
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);

        //BasicEnemy enemy = hitInfo.GetComponent<BasicEnemy>();

        EnemyController enemy = hitInfo.GetComponent<EnemyController>(); 

        if (enemy != null)
        {
            enemy.TakeDamage(this.Damage);
        }

        Destroy(gameObject);
    }
}
