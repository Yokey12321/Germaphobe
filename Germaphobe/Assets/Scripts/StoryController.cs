using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{

    public GameObject screen;
    public TMP_Text text;
    private bool dialogueBoxClicked;
    private bool dialogueRunning = false;
    private bool skipDialogue = false;
    private string introStr = @"P: 50 years ago, the residents of The Host faced their greatest threat: Jeffrey Germ. 
P: He was a notorious virus that wreaked havoc on the body during Germ War II.
R: Arteri what now? Where are we going?
W: To the heart.
R: That far? That’s a long distance though…
W: Don’t worry Redd, we got this! B positive.
R: Umm, I don’t know… I’m O negative.";

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
        yield return new WaitForSeconds(1);
        yield return runDialogue(introStr.Split('\n'));
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(2f);
    }

    protected IEnumerator runDialogue(string[] lines)
    {
        dialogueRunning = true;
        text.gameObject.transform.parent.gameObject.SetActive(true);
        IEnumerator<string> iter = ((IEnumerable<string>)lines).GetEnumerator();
        while (iter.MoveNext())
        {
            yield return runLineDialog(iter.Current);
            yield return waitForDialogueClick();
        }
        text.gameObject.transform.parent.gameObject.SetActive(false);
        dialogueRunning = false;
    }

    protected IEnumerator runLineDialog(string line)
    {
        dialogueBoxClicked = false;
        string[] data = line.Split(new char[] { ' ' }, 2);
        string s = "";
        foreach (char c in line.ToCharArray())
        {
            s += c;
            text.text = s;
            if (dialogueBoxClicked)
            {
                dialogueBoxClicked = false;
                continue;
            }
            if (skipDialogue)
            {
                text.gameObject.transform.parent.gameObject.SetActive(false);
                dialogueRunning = false;
                skipDialogue = false;
                yield break;
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    protected IEnumerator waitForDialogueClick()
    {
        bool done = false;
        while (!done)
        {
            if (dialogueBoxClicked)
            {
                dialogueBoxClicked = false;
                done = true;
            }
            yield return null;
        }
    }

    public void OnDialogueBoxClicked()
    {
        dialogueBoxClicked = true;
    }
}
