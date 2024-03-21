using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private int timeToNextSpawn = 0;
    private int time;
    public GameObject virusPrefab;

    void Start()
    {
        InvokeRepeating("TrySpawn", 5, 0);
    }
    void TrySpawn()
    {
        time++;
        if (time > timeToNextSpawn)
        {
            time = 0;
            timeToNextSpawn = Random.Range(3, 5);
            Spawn();
        }
    }
    
    void Spawn()
    {
        GameObject virus = Instantiate(virusPrefab, transform);
        virus.transform.position = new Vector3(10, 0, 0);
    }


}
