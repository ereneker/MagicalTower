using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageProjectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 15f;
    
    private Transform target;
    private float damage;
    
    public void Initialize(Transform target, float damage)
    {
        this.target = target;
        this.damage = damage;
    }

    #region MonoBehaviour

    private void Update()
    {
        BarrageAttack();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(enemy.enemyHealth ,damage);
            }

            Destroy(gameObject);
        }
    }

    #endregion

    #region Private Methods

    private void BarrageAttack()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * (projectileSpeed * Time.deltaTime);
    }

    #endregion
    
}
