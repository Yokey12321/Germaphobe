using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZincSpawner : Spawner
{

    private int timeToNextSpawn = 0;
    private float time;
    public GameObject ZincPrefab;


    protected private void FixedUpdate()
    {

    }

    void Update()
    {
        if (running)
        {
            time += Time.deltaTime;
            if (time > timeToNextSpawn)
            {
                time = 0;
                timeToNextSpawn = UnityEngine.Random.Range(10, 20);
                ZincSpawn();
            }
        }
    }

    void ZincSpawn()
    {
        GameObject Zinc;

        Zinc = Instantiate(ZincPrefab, transform);
        Zinc.transform.position = GameObject.Find("wyatt").gameObject.transform.position +  new Vector3(UnityEngine.Random.Range(-3, 3), UnityEngine.Random.Range(-3, 3), 0);

    }

}
