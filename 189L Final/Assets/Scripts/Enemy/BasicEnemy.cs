using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public int health = 1;

    public GameObject deathEffect;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
