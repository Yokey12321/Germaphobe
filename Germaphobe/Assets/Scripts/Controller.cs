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
            item.GetComponent<EnemySpawner>().StartSpawning();
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
            item.GetComponent<EnemySpawner>().EndSpawning();
        }
    }

    protected IEnumerator runDialogue(string[] lines)
    {
        text.gameObject.transform.parent.gameObject.SetActive(true);
        IEnumerator<string> iter = ((IEnumerable<string>)lines).GetEnumerator();
        iter.MoveNext();
        text.text = iter.Current;
        yield return waitForDialogueClick();
        while (iter.MoveNext())
        {
            text.text = iter.Current;
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
