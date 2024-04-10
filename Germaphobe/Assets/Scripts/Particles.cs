using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    public void StartParticles()
    {
        GetComponent<ParticleSystem>().Play();
    }

    public void StopParticles()
    {
        GetComponent<ParticleSystem>().Stop();
    }
}
