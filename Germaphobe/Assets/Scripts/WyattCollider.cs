using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wyatt;
    WyattController wyattController;

    void Start()
    {
        wyattController = wyatt.GetComponent<WyattController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MeleeVirus>() != null)
        {
            wyattController.ChangeHealth(-1);
            Debug.Log("Player collided with virus");
            StartCoroutine(wyattController.damageFlickerRoutine());
        }
    }
}
