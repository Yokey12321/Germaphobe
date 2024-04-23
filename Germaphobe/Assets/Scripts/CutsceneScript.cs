using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{

    public Sprite[] slides;
    public Image slideImage;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void setSlide(int i)
    {
        if(i < slides.Length)
        {
            slideImage.sprite = slides[i];
        }
    }
}
