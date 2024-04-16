using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public GameObject[] particles;
    public GameObject[] spawner;
    public TMP_Text text;
    private bool dialogueBoxClicked;

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
        text.gameObject.transform.parent.gameObject.SetActive(true);
        IEnumerator<string> iter = ((IEnumerable<string>)lines).GetEnumerator();
        while (iter.MoveNext())
        {
            string s = "";
            foreach (char c in iter.Current.ToCharArray())
            {
                s += c;
                text.text = s;
                if (dialogueBoxClicked)
                {
                    continue;
                }
                yield return new WaitForSeconds(0.01f);
            }
            yield return waitForDialogueClick();
        }
        text.gameObject.transform.parent.gameObject.SetActive(false);
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
