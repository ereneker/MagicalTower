using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TowerHealthBar : MonoBehaviour, ITowerObserver
{
    [SerializeField] private TowerHealthSub towerHealthSub;
    [SerializeField] private TowerHit towerHit;
    [SerializeField] private Slider healthBar;
    
    public void OnHealthBarUpdate(float currentHealth)
    {
        healthBar.value = currentHealth;
        
        towerHit.CameraShake().Forget();
    }

    #region MonoBehaviour

    private void Start()
    {
        
        healthBar.maxValue = towerHealthSub.maxHealth;
        healthBar.value = towerHealthSub.maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (towerHealthSub != null)
            {
                towerHealthSub.RegisterObserver(this);
                towerHealthSub.TakeDamage(10f);
                Destroy(other.gameObject);
            }
        }
    }

    /// <summary>
    /// Detach observer when it is destroyed to prevent memory leaks
    /// </summary>
    private void OnDestroy()
    {
        towerHealthSub.DetachObserver(this);
    }
    
    #endregion
    
    
}
