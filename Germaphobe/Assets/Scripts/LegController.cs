using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegController : Controller
{

    public GameObject screen;

    new void Start()
    {
        StartCoroutine("StartSceneFlow");
    }

    public void Update()
    {

    }

    IEnumerator StartSceneFlow()
    {
        yield return new WaitForSeconds(4);
        base.Start();
        yield return new WaitForSeconds(5);
        base.End();
    }

}
