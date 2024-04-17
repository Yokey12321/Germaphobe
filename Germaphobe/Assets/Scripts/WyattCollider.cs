using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wyatt;
    WyattController wyattController;
    AudioSource audioSource;

    void Start()
    {
        wyattController = wyatt.GetComponent<WyattController>();
        audioSource = GetComponent<AudioSource>(); 
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
        }

        if(collision.gameObject.GetComponent<Zinc>() != null)
        {
            wyattController.ChangeHealth(1);
            audioSource.Play();
            GameObject livesBar = wyatt.GetComponent<WyattLeg>().wyattLivesBar;

            Destroy(collision.gameObject);
        }
    }
}
