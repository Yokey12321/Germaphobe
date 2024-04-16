using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    protected bool running = false;

    public void StartSpawning()
    {
        running = true;
    }
    public void StopSpawning()
    {
        running = false;
    }
}
