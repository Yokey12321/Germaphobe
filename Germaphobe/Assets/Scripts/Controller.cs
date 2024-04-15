using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject[] particles;
    public GameObject[] spawner;    

    // Start is called before the first frame update
    protected void Start()
    {
        foreach (var item in particles)
        {
            item.GetComponent<Particles>().StartParticles();
        }
        foreach (var item in spawner)
        {
            item.GetComponent<EnemySpawner>().StartSpawning();
        }
    }

    protected void End()
    {
        foreach (var item in particles)
        {
            item.GetComponent<Particles>().StopParticles();
        }
        foreach (var item in spawner)
        {
            item.GetComponent<EnemySpawner>().EndSpawning();
        }
    }
}
