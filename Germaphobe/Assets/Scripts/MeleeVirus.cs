using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeVirus : MonoBehaviour
{

    public float speed = 10f;
    public GameObject healthBar;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x == -10f)
        {
           //healthBar.Damage(1);
            Destroy(gameObject);
        }
    }
}
