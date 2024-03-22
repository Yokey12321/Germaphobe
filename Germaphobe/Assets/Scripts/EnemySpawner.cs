using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private int timeToNextSpawn = 0;
    private int time;
    public GameObject virusPrefab;
    public float speed;
    private int direction = 1;
    public GameObject enemiesParent;

    void Start()
    {
        InvokeRepeating("TrySpawn", 0, 0.5f);
    }

    private void FixedUpdate()
    {
        float nextY = transform.position.y + direction * speed * Time.deltaTime;
        if (nextY > 2.5 || nextY < -2.5) {
            nextY = (5 - Math.Abs(nextY)) * direction;
            direction *= -1;
        }
        transform.position = new Vector3(transform.position.x, nextY, 0);
    }

    void TrySpawn()
    {
        time++;
        if (time > timeToNextSpawn)
        {
            time = 0;
            timeToNextSpawn = UnityEngine.Random.Range(3, 5);
            Spawn();
        }
    }
    
    void Spawn()
    {
        GameObject virus = Instantiate(virusPrefab, transform);
        virus.transform.position = new Vector3(10, transform.position.y, 0);
        virus.transform.parent = enemiesParent.transform;
        virus.layer = LayerMask.GetMask("Hittable");
    }


}
