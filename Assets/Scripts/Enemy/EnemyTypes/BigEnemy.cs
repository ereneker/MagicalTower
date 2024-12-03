using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemy : Enemy
{
    [SerializeField] [Range(1f, 2.4f)] private float movementSpeed;

    private void OnEnable()
    {
        enemyHealth = 20f;
    }

    protected override void Start()
    {
        base.Start();
        //enemyHealth = 20f;
    }

    protected override void EnemyMove()
    {
        Vector3 direction = (EnemySpawnController.Instance.transform.position - transform.position).normalized;
        transform.position += direction * (movementSpeed * Time.deltaTime);
    }
}
