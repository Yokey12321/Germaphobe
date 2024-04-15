using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenControls : MonoBehaviour
{

    public GameObject screenLeft;
    public GameObject screenRight;
    bool onLeft = true;
    bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            transform.Translate(Vector3.left * 5 * Time.deltaTime);
            if (transform.position.x >= -19.2)
            {
                return;
            }
            gameObject.transform.Translate(Vector3.right * 19.2f);
            if (onLeft)
            {
                screenLeft.transform.Translate(Vector3.right * 19.2f);
                screenRight.transform.Translate(Vector3.left * 19.2f);
            }
            else
            {
                screenLeft.transform.Translate(Vector3.left * 19.2f);
                screenRight.transform.Translate(Vector3.right * 19.2f);
            }
            onLeft = !onLeft;
        }
    }

    public void StartMotion()
    {
        running = true;
    }

    public void StopMotion()
    {
        running = false;
    }
}
