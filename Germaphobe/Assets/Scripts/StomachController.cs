using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StomachController : Controller  
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartSceneFlow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSceneFlow()
    {
        base.Prewarm();
        yield return new WaitForSeconds(10f);
        base.Start();
        yield return new WaitForSeconds(30f);
        base.End();
    }
}
