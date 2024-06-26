using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    WyattCollider wyattCollider;

    private void Start()
    {
        Invoke("Die", 3);
        wyattCollider = GameObject.Find("wyatt").GetComponentInChildren<WyattCollider>();
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
            if(SceneManager.GetActiveScene().name == "Stomach")
            {
                wyattCollider.enemiesKilled++;
                Debug.Log("Enemies killed:" + wyattCollider.enemiesKilled);
            }
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 7 || collision.gameObject.layer == 8)
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
