using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float Speed = 10.0f;
    public int Damage = 1;
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

        BasicEnemy enemy = hitInfo.GetComponent<BasicEnemy>();

        if(enemy != null)
        {
            enemy.TakeDamage(this.Damage);
        }

        Destroy(gameObject);
    }
}
