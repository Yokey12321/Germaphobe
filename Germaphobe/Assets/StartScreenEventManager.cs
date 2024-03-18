using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenEventManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Leg");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
