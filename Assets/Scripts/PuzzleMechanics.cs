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

    private void OnTriggerEnter(Collider other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MoveBlock"))
        {
            print("Working Enter");
            animate.SetBool("Pressed", true);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MoveBlock"))
        {
            print("Working Stay");
            animate.SetBool("Pressed", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MoveBlock"))
        {
            print("Working Exit");
            animate.SetBool("Pressed", false);
        }

    }


}
