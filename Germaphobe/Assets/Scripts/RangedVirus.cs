using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirus : MonoBehaviour
{

    private GameObject wyatt;
    public float speed = 10f;
    public GameObject rnaVirus;
    private GameObject projectileContainerPrefab;
    private float stoppingX;
    AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1, 3);
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > stoppingX)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(rnaVirus, transform.position, Quaternion.identity);
        EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();
        projectile.Launch(Vector2.left, 300);
        projectile.transform.parent = projectileContainerPrefab.transform;
        projectile.GetComponent<Renderer>().sortingOrder = 100;
        projectileObject.layer = LayerMask.NameToLayer("Enemies");

        audioSource.Play();
    }

    public void SetWyatt(GameObject wyatt)
    {
        this.wyatt = wyatt;
    }

    public void setProjectilePrefab(GameObject projectileContainerPrefab)
    {
        this.projectileContainerPrefab = projectileContainerPrefab;
    }

    public void setStoppingX(float x)
    {
        stoppingX = x;
    }

    public void deathAnimation()
    {
        Destroy(gameObject, 0.5f);
        animator.Play("RangedMinionDead");
    }

}
