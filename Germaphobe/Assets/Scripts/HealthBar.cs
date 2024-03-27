using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image mask;
    private float maxWidth;
    public float bodyHealth;
    private float health;
    public List<Collider> triggerList = new List<Collider>();

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = mask.rectTransform.rect.width;
        health = bodyHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int n)
    {
        health -= n;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxWidth * health/bodyHealth);
    }
}
