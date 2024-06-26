using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

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
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {;
        if (collision.gameObject.GetComponent<WyattCollider>() != null)
        {
            collision.gameObject.transform.parent.gameObject.GetComponent<WyattController>().ChangeHealth(-1);
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }
}
