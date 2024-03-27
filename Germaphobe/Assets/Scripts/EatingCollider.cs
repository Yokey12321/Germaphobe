using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MeleeVirus virus = collision.GetComponent<MeleeVirus>();
        gam
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
