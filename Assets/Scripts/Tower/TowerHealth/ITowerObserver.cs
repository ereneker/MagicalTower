using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITowerObserver
{
    void OnHealthBarUpdate(float currentHealth);
}
