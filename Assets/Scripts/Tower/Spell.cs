using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float spellCooldown = 5f;
    public float spellDamage = 10f;

    private bool onCooldown = false;
    private CancellationTokenSource _cts;
    
    protected abstract void CastSpell();

    #region MonoBehaviour

    private void OnDisable()
    {
        _cts?.Cancel();
    }

    private void Update()
    {
        TryCastSpell();
    }

    #endregion

    #region Public Methods

    public void TryCastSpell()
    {
        if (onCooldown)
        {
            Debug.Log($"{this.GetType().Name} is still on cooldown.");
            return;
        }

        
        CastSpell();
        
    }

    #endregion

    #region Reusable

    /// <summary>
    /// To prevent spawning on every Update
    /// </summary>
    protected async UniTaskVoid StartCooldown()
    {
        onCooldown = true;
        
        _cts = new CancellationTokenSource();
        CancellationToken token = _cts.Token;

        try
        {
            
            await UniTask.Delay((int)(spellCooldown * 1000), cancellationToken: token);
        }
        catch (OperationCanceledException)
        {
            Debug.Log("Cooldown was cancelled.");
        }

        
        onCooldown = false;
        Debug.Log($"{this.GetType().Name} is ready to be cast again.");
    }

    #endregion

}
