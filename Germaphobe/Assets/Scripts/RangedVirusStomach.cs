using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirusStomach : RangedVirus
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {

        base.Update();

        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        transform.Translate(transform.up * -speed *  Time.deltaTime);

        Vector2 dir = wyatt.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        lookRot.x = 0; lookRot.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
        
    }

    void Shoot()
    {
        GameObject projectileObject = Instantiate(rnaVirus, transform.position, Quaternion.identity);
        EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();
        projectile.Launch((wyatt.transform.position - transform.position).normalized * 2.0f, 300);
        projectile.transform.parent = projectileContainerPrefab.transform;
        Vector2 dir = wyatt.transform.position - transform.position;
        Quaternion lookRot = Quaternion.LookRotation(dir);
        lookRot.x = 0; lookRot.y = 0;
        projectile.transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
        projectile.GetComponent<Renderer>().sortingOrder = 100;
        projectileObject.layer = LayerMask.NameToLayer("Enemies");
        audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        if(collision.gameObject.tag == "Border")
        {
            Debug.Log("Border");
        }
    }
}
