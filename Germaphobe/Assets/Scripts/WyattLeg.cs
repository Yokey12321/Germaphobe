using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattLeg : WyattController
{

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
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        Vector2 position = rigidbody2d.position;
        position.y = Mathf.Clamp(position.y + speed * vertical * Time.deltaTime, -3, 3);
        rigidbody2d.MovePosition(position);
    }
}
