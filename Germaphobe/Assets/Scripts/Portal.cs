using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    void Start(){
        StartCoroutine("PortalFlow");
    }
    IEnumerator PortalFlow()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Leg");
    }
}
