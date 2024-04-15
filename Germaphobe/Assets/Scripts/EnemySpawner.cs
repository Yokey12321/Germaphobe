using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private int timeToNextSpawn = 0;
    private float time;
    public GameObject meleeVirusPrefab;
    public GameObject rangedVirusPrefab;
    public GameObject enemiesParent;
    public GameObject healthBar;
    public GameObject wyatt;
    public GameObject projectileContainerPrefab;
    protected Vector2 lookdir;
    private bool running = false;


    protected private void FixedUpdate()
    {

    }

    public void Update()
    {
        Debug.Log(running);
        if (running)
        {
            time += Time.deltaTime;
            if (time > timeToNextSpawn)
            {
                time = 0;
                timeToNextSpawn = UnityEngine.Random.Range(5, 10);
                Spawn();
            }
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
        virus.transform.position = new Vector3(transform.position.x, transform.position.y, 0) + transform.right * 5;
        virus.transform.parent = enemiesParent.transform;
        virus.layer = LayerMask.NameToLayer("Enemies");
    }

    public void StartSpawning()
    {
        Debug.Log("hi");
        running = true;
    }
    
    public void EndSpawning()
    {
        running = false;
    }


}
