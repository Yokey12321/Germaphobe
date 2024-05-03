using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedVirusLeg : RangedVirus
{
    //huh
    void Start()
    {
        base.Start();
    }

    void Update()
    {

        base.Update();

        if (transform.position.x > stoppingX)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }


    new void Shoot()
    {
        GameObject projectileObject = Instantiate(rnaVirus, transform.position, Quaternion.identity);
        EnemyProjectile projectile = projectileObject.GetComponent<EnemyProjectile>();
        projectile.Launch(Vector2.left, 300);
        projectile.transform.parent = projectileContainerPrefab.transform;
        projectile.GetComponent<Renderer>().sortingOrder = 100;
        projectileObject.layer = LayerMask.NameToLayer("Enemies");

        audioSource.Play();
    }


}
