using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MeleeVirus : MonoBehaviour
{

    public float speed = 10f;
    public GameObject healthBar;
    private Vector2 lookDir; 

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Leg") {
                
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x < -10f)
            {
                healthBar.GetComponent<HealthBar>().Damage(1);
                Destroy(gameObject);
                
            }
        } else {
            Vector2 dir = GameObject.Find("wyatt").transform.position - transform.position;
            Quaternion lookRot = Quaternion.LookRotation(dir);
            lookRot.x = 0; lookRot.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Mathf.Clamp01(3.0f * Time.maximumDeltaTime));
            transform.Translate(dir.normalized * speed/10 * Time.deltaTime);
        }
    }

    public void setHealthBar(GameObject health)
    {
        healthBar = health;
    }

}
