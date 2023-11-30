using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ParticleRandomColor : MonoBehaviour
{
    ParticleSystem myParticleSystem;
    ParticleSystem.ColorOverLifetimeModule colorModule;

    [SerializeField] private Gradient ourGradientMin;
    [SerializeField] private Gradient ourGradientMax;

    
    void Start()
    {
        // Get the system and the emission module.
        myParticleSystem = GetComponent<ParticleSystem>();
        colorModule = myParticleSystem.colorOverLifetime;

        // Apply the gradients.
        colorModule.color = new ParticleSystem.MinMaxGradient(ourGradientMin, ourGradientMax);

        // In 5 seconds we will modify the gradient.
        Invoke("ModifyGradient", 5.0f);
    }

    void ModifyGradient()
    {
        // Apply the changed gradients.
        colorModule.color = new ParticleSystem.MinMaxGradient(ourGradientMin, ourGradientMax);
    }

    private void OnValidate()
    {
        Invoke("ModifyGradient", 0.1f);
    }
}
