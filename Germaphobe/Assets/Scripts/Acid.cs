using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{

    private bool mature = false;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("AllowDeath", 1);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AllowDeath()
    {
        mature = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (mature && collision.gameObject.name == "stomach_outline" || mature && collision.gameObject.name.IndexOf("chicken") >= 0)
        {
            Destroy(gameObject);
        }

    }

}
