using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KioskManager : MonoBehaviour
{
    public static int playersOnPlat;

    // Start is called before the first frame update
    void Start()
    {
        playersOnPlat = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            playersOnPlat++;
    }

    void OnCollisionExit(Collision collision)
    {
        playersOnPlat--;
    }

}
