using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReddController : MonoBehaviour
{
    public float speed = 2.5f;

    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical");


    }

    void FixedUpdate()
    {
 
        Vector2 position = rigidbody2d.position;
        position.y = Mathf.Clamp(position.y + speed * vertical * Time.deltaTime, -3, 3);
        rigidbody2d.MovePosition(position);

    }
}
