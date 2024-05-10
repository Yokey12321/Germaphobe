using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryController : MonoBehaviour
{

    public GameObject screen;
    public TMP_Text text;
    public AudioSource audioSource;
    private bool dialogueBoxClicked;
    private bool dialogueRunning = false;
    private bool skipDialogue = false;
    private string introStr = @" 50 years ago, the residents of The Host faced their greatest threat: Jeffrey Germ. 
 He was a notorious virus that wreaked havoc on the body during Germ War II.
 He launched the GermNuke3000, a weapon of mass infection.
 Despite the Immune Forces' best efforts, the GermNuke was too powerful.
 Eventually, the Immune Forces were able to defeat Jeffrey Germ, but not without great loss.
 Now, Jeffrey's son, Jeremy Germ, has returned to avenge his father's defeat.
 Only one cell stands in his way: Wyatt Sangre.";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartSceneFlow");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
     void Update()
    {
        
    }

    IEnumerator StartSceneFlow()
    {
        //yield return new WaitForSeconds(1);
        yield return runDialogue(introStr.Split('\n'));
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(1);
        yield return new WaitForSeconds(3f);
        yield return new WaitForSeconds(2f);
    }

    protected IEnumerator runDialogue(string[] lines)
    {
        audioSource.Play();
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
        audioSource.Stop();
    }

    protected IEnumerator runLineDialog(string line)
    {
        dialogueBoxClicked = false;
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
