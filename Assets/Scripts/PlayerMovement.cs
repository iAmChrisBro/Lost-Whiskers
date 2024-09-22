using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 5.0f;
    float speedRotate = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f * Time.deltaTime * speed);
            movement = transform.TransformDirection(movement);
            transform.position += movement;
        }
        if (Input.GetKey("a"))
        {
            Vector3 rotation = new Vector3(0.0f, -1.0f * Time.deltaTime * speedRotate, 0.0f);
            transform.Rotate(rotation);
        }
        if (Input.GetKey("s"))
        {
            Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f * Time.deltaTime * speed);
            movement = transform.TransformDirection(movement);
            transform.position += movement;
        }
        if (Input.GetKey("d"))
        {
            Vector3 rotation = new Vector3(0.0f, 1.0f * Time.deltaTime * speedRotate, 0.0f);
            transform.Rotate(rotation);
        }
    }
}
