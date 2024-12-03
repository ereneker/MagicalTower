using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float enemyHealth = 10f;

    [SerializeField] private ParticleSystem hitParticle;
    
    protected abstract void EnemyMove();
    

    protected virtual void Start(){}

    protected virtual void Update()
    {
        EnemyMove();
    }
    

    public void TakeDamage(float health, float damageDealt)
    {
        health -= damageDealt;
        enemyHealth = health;
        if (health <= 0)
        {
            EnemyDie();
        }
    }

    private void EnemyDie()
    {
        //Hit particle to specify enemies got hit
        Instantiate(hitParticle, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z),
            Quaternion.identity);
        
        Destroy(gameObject);
    }
    
}
