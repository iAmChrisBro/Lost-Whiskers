using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;

    float speed = 5.0f;
    float speedRotate = 100.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w"))
        {
            print("w");
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f * Time.deltaTime * speed);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
        if (Input.GetKey("a"))
        {
            print("a");
            Vector3 rotation = new Vector3(0.0f, -1.0f * Time.deltaTime * speedRotate, 0.0f);
            transform.Rotate(rotation);
        }
        if (Input.GetKey("s"))
        {
            print("s");
            Vector3 movement = new Vector3(0.0f, 0.0f, -1.0f * Time.deltaTime * speed);
            movement = transform.TransformDirection(movement);
            controller.Move(movement);
        }
        if (Input.GetKey("d"))
        {
            print("d");
            Vector3 rotation = new Vector3(0.0f, 1.0f * Time.deltaTime * speedRotate, 0.0f);
            transform.Rotate(rotation);
        }
    }
}
