using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float speed;
    private bool offPlatform;
    public Transform target;
    private GameObject player1, player2, player3;
    public static int playersOnPlat;

    void Start()
    {
        playersOnPlat = 0;
    }

    void Update()
    {
        if (offPlatform)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Player")
            playersOnPlat++;
          
        offPlatform = false;
    }

    void OnCollisionStay(Collision collision)
    {
        if (playersOnPlat == 3)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        offPlatform = false;
    }

    void OnCollisionExit(Collision collision)
    {
        playersOnPlat--;
        offPlatform = true;
    }
}
