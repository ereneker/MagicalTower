using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastEnemy : Enemy
{
    [SerializeField] [Range(2f, 2.5f)] private float movementSpeed;
    
    protected override void EnemyMove()
    {
        Vector3 direction = (EnemySpawnController.Instance.transform.position - transform.position).normalized;
        transform.position += direction * (movementSpeed * Time.deltaTime);
    }
}
