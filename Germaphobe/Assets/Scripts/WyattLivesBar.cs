using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WyattLivesBar : MonoBehaviour
{
    public static WyattLivesBar instance;
    public Image mask;
    private float maxWidth;
    public float wyattLives;
    private float lives;
    // Start is called before the first frame update
    void Start()
    {
        maxWidth = mask.rectTransform.rect.width;
        lives = wyattLives;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageWyatt(float x)
    {
        lives = Math.Max(0, lives + x);
        updateWidth();
    }

    public void updateWidth()
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (lives / wyattLives) * maxWidth);
    }
}
