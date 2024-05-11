using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidSpawner : Spawner
{

    public GameObject acidPrefab;
    public GameObject wyatt;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAcid", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAcid()
    {
        if (running && wyatt != null) {
            float rad = Mathf.PI / 2 + Random.Range(-1.058f, 1.058f);
            RaycastHit2D hit = Physics2D.Raycast(wyatt.transform.position, new Vector2(Mathf.Cos(rad), Mathf.Sin(rad)), Mathf.Infinity,1 <<  8);
            GameObject acid = Instantiate(acidPrefab, hit.point, Quaternion.identity);
        }
    }
}
