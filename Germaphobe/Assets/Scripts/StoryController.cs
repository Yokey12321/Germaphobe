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
    private string introStr = @"P: Ah, the femoral artery! Only the biggest and best highway down south. What a marvel. 
P: It�s been a while since I�ve laid my eyes on such a beautiful masterpiece of arteritecture.
R: Arteri what now? Where are we going?
W: To the heart.
R: That far? That�s a long distance though�
W: Don�t worry Redd, we got this! B positive.
R: Umm, I don�t know� I�m O negative.";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
     void Update()
    {
        StartCoroutine("StartSceneFlow");
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
        string[] data = line.Split(new char[] { ' ' }, 2);
        string s = "";
        foreach (char c in line.ToCharArray())
        {
            s += c;
            text.text = s;
            if (dialogueBoxClicked)
            {
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
}
