using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrageSpell : Spell
{
    public GameObject projectilePrefab;

    protected override void CastSpell()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length == 0)
        {
            return;
        }

        foreach (Enemy enemy in enemies)
        {
            Vector3 viewportPoint = Camera.main.WorldToViewportPoint(enemy.transform.position);
            if (viewportPoint.z > 0 && viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 &&
                viewportPoint.y < 1)
            {
                
                if (projectilePrefab != null)
                {
                    GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
                    BarrageProjectile barrageProjectile = projectile.GetComponent<BarrageProjectile>();
                    if (barrageProjectile != null)
                    {
                        barrageProjectile.Initialize(enemy.transform, spellDamage);
                    }
                }
            }
        }
        StartCooldown().Forget();
    }
}