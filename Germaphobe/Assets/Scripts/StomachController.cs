using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StomachController : Controller  
{

    public GameObject lose;
    public GameObject wyatt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartSceneFlow");
        //what the heck
    }

    // Update is called once per frame
    void Update()
    {
        if (wyatt == null || wyatt.GetComponent<WyattController>().health == 0) {
            Invoke("Lose", 2);
        }
    }

    IEnumerator StartSceneFlow()
    {
        base.Prewarm();
        text.gameObject.transform.parent.gameObject.SetActive(true);
        yield return runDialogue(@"P: It's the stomach! This is the part that The Host uses to break down nutrients, and it powers Wyatt up!
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

    void Lose() {
        Time.timeScale = 0;
        lose.SetActive(true);
    }

    public void Restart() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Stomach");
    }
}
