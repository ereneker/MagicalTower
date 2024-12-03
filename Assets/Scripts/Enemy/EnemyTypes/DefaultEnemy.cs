using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : Enemy
{
    [SerializeField] [Range(1.5f, 2f)] private float movementSpeed;
    
    protected override void EnemyMove()
    {
        Vector3 direction = (EnemySpawnController.Instance.transform.position - transform.position).normalized;
        transform.position += direction * (movementSpeed * Time.deltaTime);
    }
}
