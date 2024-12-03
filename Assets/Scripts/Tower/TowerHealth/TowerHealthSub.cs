using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthSub : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;
    
    private List<ITowerObserver> observers = new List<ITowerObserver>();

    #region MonoBehaviour

    private void Start()
    {
        currentHealth = maxHealth;
    }

    #endregion

    #region Private Methods

    private void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.OnHealthBarUpdate(currentHealth);
        }
    }

    #endregion
    
    #region Public Methods

    public void RegisterObserver(ITowerObserver observer)
    {
        if (!observers.Contains(observer))
        {
            observers.Add(observer);
        }
    }
    
    public void DetachObserver(ITowerObserver observer)
    {
        if (observers.Contains(observer))
        {
            observers.Remove(observer);
        }
    }
    
    /// <summary>
    /// Will trigger this in Enemy script
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        NotifyObservers();
        
        
        if (currentHealth == 0)
        {
            //Will Restart or return menu
            Destroy(gameObject.transform.parent.gameObject);
            Debug.Log("Game Over: The tower has fallen.");
        }
    }

    #endregion
}
