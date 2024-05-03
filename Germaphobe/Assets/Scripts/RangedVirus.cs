using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirus : MonoBehaviour
{

    protected GameObject wyatt;
    public float speed = 10f;
    public GameObject rnaVirus;
    protected GameObject projectileContainerPrefab;
    protected float stoppingX;
    protected AudioSource audioSource;
    Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        InvokeRepeating("Shoot", 1, 3);
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
    void Shoot()
    {
    }

    public void SetWyatt(GameObject wyatt)
    {
        this.wyatt = wyatt;
    }

    public void setProjectilePrefab(GameObject projectileContainerPrefab)
    {
        this.projectileContainerPrefab = projectileContainerPrefab;
    }

    

    public void deathAnimation()
    {
        Destroy(gameObject, 0.5f);
        animator.Play("RangedMinionDead");
    }

    public void setStoppingX(float x)
    {
        stoppingX = x;
    }
}
