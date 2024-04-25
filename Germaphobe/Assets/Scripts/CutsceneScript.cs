using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{

    public Sprite[] slides;
    public Image slideImage;
    private int index;

    void Start()
    {
        index = 0;
        slideImage.sprite = slides[index];
        index++;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            if(index >= slides.Length)
            {
                SceneManager.LoadScene("Leg");
            }
            if(index < slides.Length)
            {
                slideImage.sprite = slides[index];
                index++;
            }
            
        }
    }

    public void setSlide(int i)
    {
        if(i < slides.Length)
        {
            slideImage.sprite = slides[i];
        }
    }
}
