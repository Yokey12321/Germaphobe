using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutsceneScript : MonoBehaviour
{

    public Sprite[] slides;
    public Image slideImage;
    private int index;

    void Start()
    {
        index = 0;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0) == true)
        {
            slideImage.sprite = slides[index];
            index++;
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
