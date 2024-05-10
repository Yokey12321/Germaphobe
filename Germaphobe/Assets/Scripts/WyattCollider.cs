using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattCollider : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject wyatt;
    WyattController wyattController;
    AudioSource audioSource;

    public GameObject lockToActivate;
    public int enemiesKilled;
    void Start()
    {
        wyattController = wyatt.GetComponent<WyattController>();
        audioSource = GetComponent<AudioSource>(); 
        enemiesKilled = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesKilled >= 1){
            lockToActivate.SetActive(true);
            enemiesKilled = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MeleeVirus>() != null)
        {
            wyattController.ChangeHealth(-1);
        }

        if(collision.gameObject.GetComponent<Zinc>() != null)
        {
            if (wyatt.GetComponent<WyattController>().isMaxHealth())
                return;
            wyattController.ChangeHealth(1);
            audioSource.Play();
            Destroy(collision.gameObject);
        }
    }
}
