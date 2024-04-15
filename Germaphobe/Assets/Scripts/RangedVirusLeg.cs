using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirusLeg : RangedVirus
{
    //huh
    void Start()
    {
        base.Start();
    }

    void Update()
    {

        base.Update();

        if (transform.position.x > stoppingX)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

}
