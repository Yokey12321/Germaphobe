using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StairwayToHeaven : MonoBehaviour
{
    private bool wtf;
    public GameObject portal;
    void Start()
    {
        //portal = gameObject.GetComponent<Portal>();
        wtf = false;
    }
    void Update()
    {
        if(wtf){
            portal.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        Debug.Log("BRO IS THIS WORKING");
        if(other.gameObject.tag == "Player"){
            wtf = true;
            Debug.Log("Player has entered the stairway to heaven!");
        }
    }

}
