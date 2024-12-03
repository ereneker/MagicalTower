using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class TowerHit : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.5f; 
    [SerializeField] private float shakeMagnitude = 0.3f; 

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.localPosition;
    }

    public async UniTaskVoid CameraShake()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = originalPosition + randomOffset;

            elapsedTime += Time.deltaTime;
            await UniTask.Yield();
        }

        transform.localPosition = originalPosition;
    }
}
