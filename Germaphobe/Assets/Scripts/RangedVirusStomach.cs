using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirusStomach : RangedVirus
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {

        base.Update();

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        transform.Translate(transform.up * -speed *  Time.deltaTime);


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Border")
        {
            Debug.Log("Border");
            transform.Rotate(0, 0, 180);
        }
    }
}
