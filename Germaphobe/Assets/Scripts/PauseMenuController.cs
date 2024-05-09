using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{

    private bool main = true;
    public GameObject menu;
    public GameObject credits;
    public GameObject buttons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Back() {
        if (main) {
            menu.SetActive(false);
            Time.timeScale = 1;
        } else {
            main = true;
            credits.SetActive(false);
            buttons.SetActive(true);
        }
    }
    
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void Exit() {
        Application.Quit();
    }

    public void Credits() {
        main = false;
        credits.SetActive(true);
        buttons.SetActive(false);
    }


}
