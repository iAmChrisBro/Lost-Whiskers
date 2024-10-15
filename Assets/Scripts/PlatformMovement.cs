using UnityEngine;

public class PointMovement : MonoBehaviour
{
    public float speed;
    private bool offPlatform;
    public Transform target;

    void Update()
    {
        if(offPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        offPlatform = false;
    }

    void OnCollisionStay(Collision collision)
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        offPlatform = false;
    }

    void OnCollisionExit(Collision collision)
    {
        offPlatform = true;
    }
}
  
