using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattMoveLeg : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject projectilePrefab;
    public GameObject projectileContainerPrefab;

    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public AudioSource AudioSource;

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        

        if (Input.GetKeyDown(KeyCode.C))
        {
            Launch();

            animator.Play("WyattShoot");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Eat();
        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.y = Mathf.Clamp(position.y + speed * vertical * Time.deltaTime, -3, 3);
        rigidbody2d.MovePosition(position);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        projectile.transform.parent = projectileContainerPrefab.transform;
        //animator.SetTrigger("Launch");
    }

    void Eat()
    {
        animator.Play("WyattEat");
        AudioSource.Play();
    }
}

