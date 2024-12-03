using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell
{
    [SerializeField] private GameObject fireballPrefab;

    private float explosionRadius = 5f;
    
    protected override void CastSpell()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        if (enemies.Length == 0)
        {
            return;
        }

        GameObject target = enemies[Random.Range(0, enemies.Length)].gameObject;

        if (fireballPrefab != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            FireballProjectile projectile = fireball.GetComponent<FireballProjectile>();
            if (projectile != null)
            {
                projectile.Initialize(target.transform, spellDamage, explosionRadius);
            }
        }
        
        StartCooldown().Forget();
    }
}
