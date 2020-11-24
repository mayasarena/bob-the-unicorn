using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private ParticleSystem particleSys;

    void Start()
    {
        particleSys = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (!particleSys.isPlaying)
        {
            Destroy(gameObject); // Destroy the particle systems after they're played
        }
    }
}
