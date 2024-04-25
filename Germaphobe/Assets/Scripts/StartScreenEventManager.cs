using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenEventManager : MonoBehaviour
{

    AudioSource audioSource;

    public void StartGame()
    {
        //audioSource = GetComponent<AudioSource>();
        //audioSource.Play();
        //3 second delay before next command
        //Invoke("LoadGame", 3);

        SceneManager.LoadScene("StoryIntroduction"); 
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Leg");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
