using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WyattController : MonoBehaviour
{
    public float speed = 3.0f;
    protected float vertical;
    protected float horizontal;

    public GameObject projectilePrefab;
    public GameObject projectileContainerPrefab;
    public float projectileCooldown;
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    private bool isFlickering = false;
    private float projectileTime = 0;
    protected Vector2 lookdir;

    public ParticleSystem eatingParticles;

    public int maxHealth = 5;
    public int health { get { return currentHealth; } }
    int currentHealth;

    public float timeInvincible = 2.0f;
    bool isInvincible;
    float invincibleTimer;

    protected Rigidbody2D rigidbody2d;
    AudioSource audioSource;

    private List<GameObject> eatableViruses = new List<GameObject>(); 

    Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
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

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }   

    }

    protected virtual void FixedUpdate() {
        projectileTime = Mathf.Clamp(projectileTime + Time.deltaTime, 0, projectileCooldown);
    }

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookdir, 300);
        Debug.Log(lookdir);
        projectile.transform.parent = projectileContainerPrefab.transform;
        projectile.GetComponent<Renderer>().sortingOrder = 100;
        //animator.SetTrigger("Launch");
    }

    public void ChangeHealth(int amount)
    {
        if(amount < 0)
        {
            isFlickering = true;

            StartCoroutine(damageFlickerRoutine());
            WyattLivesBar.instance.DamageWyatt(amount);

            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void Eat()
    { 
        animator.Play("WyattEat");
        audioSource.Play();
        Debug.Log(eatableViruses.Count);
        if (eatableViruses.Count > 0)
        {
            Destroy(eatableViruses[0]);
            eatingParticles.Play();
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

    public IEnumerator damageFlickerRoutine()
    {
        while(isFlickering == true)
        {
            WaitForSeconds wait = new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color32(255, 100, 100, 255);
            yield return wait;
            spriteRenderer.color = Color.white;
            yield return wait;
            spriteRenderer.color = new Color32(255, 100, 100, 255);
            yield return wait;
            spriteRenderer.color = Color.white;
            yield return wait;
            spriteRenderer.color = new Color32(255, 100, 100, 255);
            yield return wait;
            spriteRenderer.color = Color.white;
            yield return wait;
            spriteRenderer.color = new Color32(255, 100, 100, 255);
            yield return wait;
            spriteRenderer.color = Color.white;
            yield return wait;
            isFlickering = false;  
        }
    }

}

