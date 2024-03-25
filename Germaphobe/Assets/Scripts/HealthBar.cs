using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image mask;
    private float maxWidth;
    public float bodyHealth;
    private float health;
    private string time;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = mask.rectTransform.rect.width;
        health = bodyHealth;
        Debug.Log(health);
        time = "q";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int n)
    {
        Debug.Log(health);
        health -= n;
        Debug.Log(time);
        Debug.Log(n);
        Debug.Log(health/bodyHealth);
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, maxWidth * health/bodyHealth);
    }
}
