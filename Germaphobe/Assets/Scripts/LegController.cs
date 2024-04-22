using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LegController : Controller
{

    public GameObject screen;
    private string dialogueStr = @"P: Ah, the femoral artery! Only the biggest and best highway down south. What a marvel. 
P: It’s been a while since I’ve laid my eyes on such a beautiful masterpiece of arteritecture.
R: Arteri what now? Where are we going?
W: To the heart.
R: That far? That’s a long distance though…
W: Don’t worry Redd, we got this! B positive.
R: Umm, I don’t know… I’m O negative.
P: Hey guys… Viruses ahead. Make sure to keep an IgG ahead. Speaking of Immunoglobulin G, did you know it’s the most common type of antibody in the blood?
W: Yeah, we know. I’m a white blood cell after all. Heck I got the B Cell blaster, so I launch those things with the C key. 
P: You’re right. 
R: Wait, Wyatt. You can also eat viruses with SPACE right?
P: Only the viruses with the boxing gloves right? Those viruses who stay behind are immune! That's what the Immunoglobulin is for. 
W: That’s correct, Redd and Plato. I’m a macrophage after all. Now let’s send these viruses to outer space.";
    private string dialogueStr2 = @"P: Hey Wyatt, I picked up some of that floating Zinc to heal you back to max health in the stomach.
W: Thanks, Plato.
P: No problem. Zinc is super healthy for white blood cells like you.
W: We’ve reached the stomach, so leave the zinc behind. There'll be more later.
P: Alright then, let’s go!";
    new void Start()
    {
        StartCoroutine("StartSceneFlow");
    }


    new void Update()
    {
        base.Update();
    }

    IEnumerator StartSceneFlow()
    {
        base.Prewarm();
        yield return new WaitForSeconds(1);
        yield return runDialogue(dialogueStr.Split('\n'));
        base.Start();
        screen.GetComponent<ScreenControls>().StartMotion();
        yield return new WaitForSeconds(30);
        base.End();
        yield return new WaitForSeconds(5);
        screen.GetComponent<ScreenControls>().StopMotion();
        yield return runDialogue(dialogueStr2.Split('\n'));
        SceneManager.LoadScene("Stomach");
    }

}
