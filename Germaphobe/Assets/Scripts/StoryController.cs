using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : Controller
{

    public GameObject screen;
    private string introStr = @"P: Ah, the femoral artery! Only the biggest and best highway down south. What a marvel. 
P: It’s been a while since I’ve laid my eyes on such a beautiful masterpiece of arteritecture.
R: Arteri what now? Where are we going?
W: To the heart.
R: That far? That’s a long distance though…
W: Don’t worry Redd, we got this! B positive.
R: Umm, I don’t know… I’m O negative.";

    // Start is called before the first frame update
    new void Start()
    {
        StartCoroutine("StartStoryFlow");
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }

    IEnumerator StartStoryFlow()
    {
        base.Prewarm();
        yield return new WaitForSeconds(1);
        yield return runDialogue(introStr.Split('\n'));
        yield return new WaitForSeconds(1);
        base.Start();
        screen.GetComponent<ScreenControls>().StartMotion();
        yield return new WaitForSeconds(1);
        base.End();
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(2f);
        screen.GetComponent<ScreenControls>().StopMotion();
    }
}
