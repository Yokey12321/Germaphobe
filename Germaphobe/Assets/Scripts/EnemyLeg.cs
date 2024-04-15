using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeg : EnemySpawner
{
    // Start is called before the first frame update
    private int direction = 1;
    public float speed;
    void Start()
    {
        base.lookdir = Vector2.left;
    }

    new void FixedUpdate()
    {
        base.FixedUpdate();
        float nextY = transform.position.y + direction * speed * Time.deltaTime;
        if (nextY > 2.5 || nextY < -2.5)
        {
            nextY = (5 - Mathf.Abs(nextY)) * direction;
            direction *= -1;
        }
        transform.position = new Vector3(transform.position.x, nextY, 0);
    }
}
