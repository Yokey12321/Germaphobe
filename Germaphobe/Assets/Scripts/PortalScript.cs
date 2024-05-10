using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartPortalFlow");
    }
    void Update()
    {

    }

    IEnumerator StartPortalFlow()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("End");
    }
}
