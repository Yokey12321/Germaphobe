using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattStomach : WyattController
{
    public float rotationSpeed;
    private float dashTimer = 0;
    public float dashCooldown;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        lookdir = Vector2.right;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        Debug.Log(Input.GetKeyDown(KeyCode.X));
        if (Input.GetKeyDown(KeyCode.X) && dashTimer == dashCooldown)
        {
            Debug.Log("hi");
            Dash();
            dashTimer = 0;
        }
    }

    protected new void FixedUpdate()
    {
        base.FixedUpdate();
        dashTimer = Mathf.Clamp(dashTimer + Time.deltaTime, 0, dashCooldown);
        if (!(Mathf.Floor(horizontal) == 0 && Mathf.Floor(vertical) == 0))
        {
            /*
            float originalangle = Vector2.SignedAngle(Vector2.right, lookdir) + 170;
            float targetangle = Vector2.SignedAngle(Vector2.right, new Vector2(Mathf.Floor(horizontal), Mathf.Floor(vertical))) + 170;
            float delangle = Mathf.Abs(originalangle - targetangle);
            float finalangle;
            
            if (delangle > 180)
            {
                if (targetangle > originalangle)
                {
                    finalangle = Mathf.Clamp((originalangle + 360 - rotationSpeed * Time.deltaTime), originalangle + 360, targetangle) % 360 - 170;
                } else
                {
                    finalangle = Mathf.Clamp((originalangle + rotationSpeed * Time.deltaTime), targetangle, originalangle + 360) % 360 - 170;
                }
            }
            else
            {
                if (targetangle > originalangle)
                {
                    finalangle = Mathf.Clamp((originalangle + rotationSpeed * Time.deltaTime), originalangle, targetangle) % 360 - 170;
                }
                else
                {
                    finalangle = Mathf.Clamp((originalangle - rotationSpeed * Time.deltaTime), targetangle, originalangle) % 360 - 170;
                }
            }
            Debug.Log("f" + finalangle);
            lookdir = Quaternion.AngleAxis(finalangle, Vector3.forward) * Vector2.right;
            transform.rotation = Quaternion.Euler(0, 0, finalangle);
            */
            transform.Translate(new Vector2(horizontal, vertical) * speed * Time.deltaTime, Space.World);
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
