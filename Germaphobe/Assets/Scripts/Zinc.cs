using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zinc : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        WyattController controller = other.GetComponent<WyattController>();
    }

}
