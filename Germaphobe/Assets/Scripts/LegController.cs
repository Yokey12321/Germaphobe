using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LegController : Controller
{

    public GameObject screen;
    private string dialogueStr = @"P: Ah, the femoral artery! Only the biggest and best highway down south. What a marvel. 
P: It’s been a while since I’ve laid my eyes on such a beautiful masterpiece of arteritecture.
R: Arteri what now? Where are we going?
W: To the heart.
R: That far? That’s a long distance though…
W: Don’t worry Redd, we got this! B positive.
R: Umm, I don’t know… I’m O negative.";
    private string dialogueStr2 = @"P: Hey Wyatt, I picked up some of that floating Zinc to heal you back to max health in the stomach.
W: Thanks, Plato.
P: No problem. Zinc is super healthy for white blood cells like you.
W: We’ve reached the stomach, so leave the zinc behind. There'll be more later.
P: Alright then, let’s go!";

    public GameObject wyatt;
    public GameObject rnaPiece;
    private bool pieceMoving = false;
    private bool wyattMoving = false;
    private bool meleeMoving = false;
    private bool rangedMoving = false;
    private GameObject r;
    private GameObject melee;
    private GameObject ranged;
    private bool spacePressed = false;

    new void Start()
    {
        StartCoroutine("StartSceneFlow");
    }


    new void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePressed = true;
        }
    }

    IEnumerator StartSceneFlow()
    {
        base.Prewarm();
        yield return new WaitForSeconds(1);
        yield return runDialogue(dialogueStr.Split('\n'));
        yield return new WaitForSeconds(1);
        yield return meleeTutorial();
        yield return rangedTutorial();
        base.Start();
        screen.GetComponent<ScreenControls>().StartMotion();
        yield return new WaitForSeconds(1);
        base.End();
        yield return new WaitForSeconds(3f);
        spawnRna();
        yield return new WaitForSeconds(2f);
        screen.GetComponent<ScreenControls>().StopMotion();
        wyattMoving = true;
        yield return runDialogue(dialogueStr2.Split('\n'));
        SceneManager.LoadScene("Stomach");
    }

    public void rnaPieceCollection()
    {

    }

    void spawnRna()
    {
        r = Instantiate(rnaPiece, new Vector3(10, 0, 0), Quaternion.identity);
        pieceMoving = true;
    }

    void spawnMelee()
    {
        Sprite sprite = spawner[0].GetComponent<EnemySpawner>().meleeVirusPrefab.GetComponent<SpriteRenderer>().sprite;
        melee = new GameObject("melee dummy");
        melee.transform.position = new Vector3(10, 0);
        melee.AddComponent<SpriteRenderer>().sprite = sprite;
        meleeMoving = true;
        melee.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    void spawnRanged()
    {
        Sprite sprite = spawner[0].GetComponent<EnemySpawner>().meleeVirusPrefab.GetComponent<SpriteRenderer>().sprite;
        ranged = new GameObject("melee dummy");
        ranged.transform.position = new Vector3(10, 0);
        ranged.AddComponent<SpriteRenderer>().sprite = sprite;
        ranged.transform.localScale = new Vector3(0.5f, 0.5f);
    }

    IEnumerator meleeTutorial()
    {
        spawnMelee();
        text.gameObject.transform.parent.gameObject.SetActive(true);
        yield return runLineDialog("P: Hey guys... Virus ahead! Quick, Wyatt press SPACE to eat them!");
        while (meleeMoving || !spacePressed)
        {
            yield return null;
        }
        spacePressed = false;
        Destroy(melee);
        yield return runDialogue(new string[]{ "W: I know, I know."});
    }
    
    IEnumerator rangedTutorial()
    {
        spawnRanged();
        text.gameObject.transform.parent.gameObject.SetActive(true);
        yield return runDialogue(("P: Hey guys... Virus ahead! This time, I think they're gonna keep their distance!" +
            "\nR: Wyatt, don't you have that blaster?").Split('\n'));
        yield return runLineDialog("W: I do. Time to press C and shoot them away!");
        rangedMoving = true;
        while (meleeMoving || !spacePressed)
        {
            yield return null;
        }
        spacePressed = false;
        Destroy(melee);
        yield return runLineDialog("P: Nice! Make sure to keep an IgG ahead. Speaking of IgG, did you know it’s the most common type of antibody in the blood?");
        yield return runLineDialog("W: Yeah, we know. I’m a white blood cell after all. You saw the B Cell blaster. The things I shoot are IgG.");
        yield return runLineDialog("P: That's true! However, I think the viruses that just come at you are immune. Be sure to eat them before they eat you.");
        yield return runLineDialog("W: Got it. I see more ahead. Let's blast these viruses to outer space.");
    }

    private void FixedUpdate()
    {
        if (pieceMoving)
        {

            Vector3 newPos = Vector3.MoveTowards(r.transform.position, Vector3.zero, 5 * Time.deltaTime);
            if (newPos == r.transform.position)
            {
                pieceMoving = false;
            }
            r.transform.position = newPos;
        }
        if (wyattMoving)
        {
            Vector3 newPos = Vector3.MoveTowards(wyatt.transform.position, Vector3.zero, 5 * Time.deltaTime);
            if (newPos == wyatt.transform.position)
            {
                wyattMoving = false;
            }
            wyatt.transform.position = newPos;
        }
        if (rangedMoving)
        {
            Vector3 newPos = Vector3.MoveTowards(ranged.transform.position, new Vector3(7, 0), 5 * Time.deltaTime);
            if (newPos == ranged.transform.position)
            {
                rangedMoving = false;
            }
            ranged.transform.position = newPos;
        }
        if (meleeMoving)
        {
            Vector3 newPos = Vector3.MoveTowards(melee.transform.position, new Vector3(-4.7f, 0), 5 * Time.deltaTime);
            if (newPos == melee.transform.position)
            {
                meleeMoving = false;
            }
            melee.transform.position = newPos;
        }
    }

}
