
using UnityEngine;

public class Zinc : MonoBehaviour
{
    float direction;
    float rotSpeed;
    private void Start()
    {
        float rand = Random.Range(0.0f, 1.0f);
        direction = (rand <= 0.5f) ? 1f : -1f;
        rotSpeed = 200f;
    }

    private void Update()
    {
        float multiplier = Random.Range(0.5f, 1.0f);
        Debug.Log(Time.deltaTime * direction * multiplier * rotSpeed);
        transform.Rotate(new Vector3(0, 0, rotSpeed * Time.deltaTime * direction * multiplier), Space.World);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        WyattController controller = other.GetComponent<WyattController>();
    }

}
