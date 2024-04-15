using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirusStomach : RangedVirus
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {

        base.Update();

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        transform.Translate(transform.up * -speed *  Time.deltaTime);
        
    }
}
