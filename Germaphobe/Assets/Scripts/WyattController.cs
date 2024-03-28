using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattController : MonoBehaviour
{
    public float speed = 3.0f;

    public GameObject projectilePrefab;
    public GameObject projectileContainerPrefab;
    public float projectileCooldown;
    [SerializeField]
    private float projectileTime = 0;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    protected Rigidbody2D rigidbody2d;
    AudioSource audioSource;

    private List<GameObject> eatableViruses = new List<GameObject>(); 

    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && projectileCooldown == projectileTime)
        {
            Launch();

            projectileTime = 0;

            animator.Play("WyattShoot");
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Eat();
        }

    }

    protected virtual void FixedUpdate() {
        projectileTime = Mathf.Clamp(projectileTime + Time.deltaTime, 0, projectileCooldown);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        projectile.transform.parent = projectileContainerPrefab.transform;
        projectile.GetComponent<Renderer>().sortingOrder = 100;
        //animator.SetTrigger("Launch");
    }

    void Eat()
    { 
        animator.Play("WyattEat");
        audioSource.Play();
        Debug.Log(eatableViruses.Count);
        if (eatableViruses.Count > 0)
        {
            Destroy(eatableViruses[0]);
        }
    }

    public void addToList(GameObject virus)
    {
        eatableViruses.Add(virus);
    }

    public void removeFirstVirusFromList()
    {
        eatableViruses.RemoveAt(0);
    }
}

