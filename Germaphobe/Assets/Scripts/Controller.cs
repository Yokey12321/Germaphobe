using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Controller : MonoBehaviour
{

    public GameObject[] particles;
    public GameObject[] spawner;
    public TMP_Text text;
    public Image icon;
    private bool dialogueBoxClicked;
    public GameObject sprites;
    private bool dialogueRunning = false;
    private bool skipDialogue = false;

    // Start is called before the first frame update

    protected void Prewarm()
    {
        foreach (var item in particles)
        {
            item.GetComponent<Particles>().StartParticles();
            item.GetComponent<Particles>().PauseParticles();
        }
    }

    protected void Start()
    {
        foreach (var item in particles)
        {
            item.GetComponent<Particles>().StartParticles();
        }
        foreach (var item in spawner)
        {
            item.GetComponent<Spawner>().StartSpawning();
        }
    }

    protected void Update()
    {
        if (dialogueRunning && Input.GetKeyDown("h"))
        {
            skipDialogue = true;
            dialogueBoxClicked = true;
        }
    }

    protected void End()
    {
        foreach (var item in particles)
        {
            item.GetComponent<Particles>().StopParticles();
        }
        foreach (var item in spawner)
        {
            item.GetComponent<Spawner>().StopSpawning();
        }
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
    
    protected IEnumerator runDialogue(string line)
    {
        yield return runDialogue(new string[] {line});
    }

    protected IEnumerator runLineDialog(string line)
    {
        dialogueBoxClicked = false;
        string[] data = line.Split(new char[] { ' ' }, 2);
        icon.GetComponent<Image>().sprite = sprites.GetComponent<DialogueSprites>().getIcon(data[0].Substring(0, 1));
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
        while(!done)
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
