using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanics : MonoBehaviour
{
    public Transform pressurePlate;
    public Animator animate;
    
    void Start()
    {
        animate.SetBool("Pressed", false);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player"))
        {
            print("Working Enter");
            animate.SetBool("Pressed", true);
        }

    }

    private void OnCollisionExit(Collision other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player"))
        {
            print("Working Exit");
            animate.SetBool("Pressed", false);
        }

    }


}
