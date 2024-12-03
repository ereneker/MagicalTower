using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class FireballProjectile : MonoBehaviour
{
    [FormerlySerializedAs("speed")] [SerializeField] private float projectileSpeed = 10f; 
    private Transform target;
    private float damage;
    private float explosionRadius;

    public void Initialize(Transform target, float damage, float explosionRadius)
    {
        this.target = target;
        this.damage = damage;
        this.explosionRadius = explosionRadius;
    }

    #region MonoBehaviour

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * (projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == target)
        {
            Explode();
        }
    }

    #endregion

    #region Private Methods

    //AOE damage
    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(enemy.enemyHealth, damage);
            }
        }

        Destroy(gameObject);
    }

    #endregion
}