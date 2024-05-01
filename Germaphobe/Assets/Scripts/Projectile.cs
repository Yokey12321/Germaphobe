using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    private void Start()
    {
        Invoke("Die", 3);
    }

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<RangedVirus>() != null)
        {
            collision.gameObject.GetComponent<RangedVirus>().deathAnimation();
            /*Destroy(collision.gameObject);*/
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name == "ranged dummy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    
    public void Die()
    {
        Destroy(gameObject);
    }
}
