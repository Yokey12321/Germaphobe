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
        text.gameObject.transform.parent.gameObject.SetActive(true);
        yield return runDialogue(@"P: It's the stomach!
W: We're here!
P: And so are the viruses.
W: Let's just eliminate them quickly. I'm getting a bad feeling in my gut.
P: Wyatt! I didn't expect you to crack a joke just then!
W: A joke? What? Oh. Plato, this is a serious situation.
P: Sorry, sorry. Let's just focus on virus extermination.".Split('\n'));
        base.Start();
        yield return new WaitForSeconds(30f);
        base.End();
    }
}
