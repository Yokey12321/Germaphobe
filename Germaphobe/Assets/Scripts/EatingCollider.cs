using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wyatt;
    private WyattController wyattScript;
    void Start()
    {
        wyattScript = wyatt.GetComponent<WyattController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hi");
        MeleeVirus virus = collision.GetComponent<MeleeVirus>();
        if (virus != null)
        {
            wyattScript.addToList(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MeleeVirus virus = collision.GetComponent<MeleeVirus>();
        WyattController Weeyat = wyatt.GetComponent<WyattController>();    
        if (virus != null)
        {
            wyattScript.removeFirstVirusFromList();

            Weeyat.ChangeHealth(-1);
            Debug.Log("Player collided with virus");
        }
    }
}
