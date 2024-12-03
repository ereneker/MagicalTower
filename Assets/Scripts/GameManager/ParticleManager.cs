using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    private void Start()
    {
        ParticleSystem _particleSystem = GetComponent<ParticleSystem>();

        Destroy(gameObject, _particleSystem.main.duration + _particleSystem.main.startLifetime.constantMax);
    }
}
