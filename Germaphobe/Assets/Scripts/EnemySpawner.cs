using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private int timeToNextSpawn = 0;
    private int time;
    public GameObject meleeVirusPrefab;
    public GameObject rangedVirusPrefab;
    public float speed;
    private int direction = 1;
    public GameObject enemiesParent;
    public GameObject healthBar;
    public GameObject wyatt;
    public GameObject projectileContainerPrefab;

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
            timeToNextSpawn = UnityEngine.Random.Range(5, 10);
            Spawn();
        }
    }
    
    void Spawn()
    {
        GameObject virus;
        if (UnityEngine.Random.Range(0f, 1f) > 0.5f)
        {
            virus = Instantiate(meleeVirusPrefab, transform);
            virus.GetComponent<MeleeVirus>().setHealthBar(healthBar);
        } else
        {
            virus = Instantiate(rangedVirusPrefab, transform);
            virus.GetComponent<RangedVirus>().SetWyatt(wyatt);
            virus.GetComponent<RangedVirus>().setProjectilePrefab(projectileContainerPrefab);
            virus.GetComponent<RangedVirus>().setStoppingX(UnityEngine.Random.Range(4f, 7f));
        }
        virus.transform.position = new Vector3(10, transform.position.y, 0);
        virus.transform.parent = enemiesParent.transform;
        virus.layer = LayerMask.NameToLayer("Enemies");
    }


}
