using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WyattLivesBar : MonoBehaviour
{
    public Image mask;
    private float maxWidth;
    public float bodyHealth;
    private float health;
    // Start is called before the first frame update
    void Start()
    {
        maxWidth = 266f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
