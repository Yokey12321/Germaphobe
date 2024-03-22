using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image mask;
    private float maxWidth;
    public float bodyHealth;

    // Start is called before the first frame update
    void Start()
    {
        maxWidth = mask.preferredWidth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Demage(int n)
    {
        bodyHealth -= n;
    }
}
