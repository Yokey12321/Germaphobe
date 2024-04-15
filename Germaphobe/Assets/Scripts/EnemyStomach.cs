using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStomach : EnemySpawner
{

    public float rotSpeed;

    // Start is called before the first frame update
    new void Start()
    {
        base.StartSpawning();
    }

    // Update is called once per frame
    new void FixedUpdate()
    {
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime), Space.World);
    }
}
