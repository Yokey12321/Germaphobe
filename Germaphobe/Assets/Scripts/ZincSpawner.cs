using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (GameObject.Find("wyatt") == null) {
            running = false;
            return;
        }
        Zinc.transform.position = GameObject.Find("wyatt").gameObject.transform.position +  new Vector3(SceneManager.GetActiveScene().name == "Stomach" ? UnityEngine.Random.Range(-3, 3) : 0, UnityEngine.Random.Range(-3, 3), 0);

    }

}
