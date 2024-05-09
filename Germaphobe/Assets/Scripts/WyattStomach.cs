using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattStomach : WyattController
{
    public float rotationSpeed;
    private float dashTimer = 0;
    public float dashCooldown;
    public bool hasKey;
    
    public WyattCollider wyattCollider;
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        lookdir = Vector2.right;
        hasKey = true;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.X) && dashTimer == dashCooldown)
        {
            Dash();
            dashTimer = 0;
        }

        if(ate){
            wyattCollider.enemiesKilled++;
            Debug.Log("Enemies killed: " + wyattCollider.enemiesKilled);
            ate = false;
        }
    }

    protected new void FixedUpdate()
    {
        base.FixedUpdate();
        dashTimer = Mathf.Clamp(dashTimer + Time.deltaTime, 0, dashCooldown);
        if (!(Mathf.Floor(horizontal) == 0 && Mathf.Floor(vertical) == 0))
        {
            rigidbody2d.AddForce(new Vector2(horizontal, vertical) * speed * Time.deltaTime, ForceMode2D.Impulse);
            base.lookdir = Quaternion.AngleAxis(Vector2.SignedAngle(Vector2.right, new Vector2(horizontal, vertical)), Vector3.forward) * Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, new Vector2(horizontal, vertical)));
            transform.localScale = new Vector3(transform.localScale.x, Mathf.Abs(transform.localScale.y) * (horizontal <= 0 ? -1 : 1), 1);
        }

    }

    public void Dash()
    {
        rigidbody2d.AddForce(lookdir * 200);
    }

}
