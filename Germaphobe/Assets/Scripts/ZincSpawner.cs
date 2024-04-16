using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZincSpawner : MonoBehaviour
{

    private int timeToNextSpawn = 0;
    private float time;
    public GameObject ZincPrefab;
    private bool runningZinc = false;


    protected private void FixedUpdate()
    {

    }

    private void Start()
    {
        runningZinc = true;
    }

    void Update()
    {
        Debug.Log(runningZinc);
        if (runningZinc)
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
        Zinc.transform.position = new Vector3(-7, UnityEngine.Random.Range(-3, 3.5f), 0);

    }

}
