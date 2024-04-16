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
    // Start is called before the first frame update
    void Start()
    {
        maxWidth = mask.rectTransform.rect.width;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateWidth(float percentage)
    {
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, percentage * maxWidth);
    }
}
