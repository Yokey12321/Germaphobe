using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockScript : MonoBehaviour
{
    
    public GameObject portal;
    

    void Start()
    {
        
    }
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other){
        
        portal.SetActive(true);
        Destroy(gameObject);
        
    }
}
