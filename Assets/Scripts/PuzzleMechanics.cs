using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMechanics : MonoBehaviour
{
    public Transform pressurePlate;
    public Animator animatePlate, animateDoor;

    private void OnTriggerEnter(Collider other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MoveBlock"))
        {
            animatePlate.SetBool("Pressed", true);
            animateDoor.SetBool("isOpen", true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (pressurePlate != null && other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MoveBlock"))
        {
            animatePlate.SetBool("Pressed", false);
            animateDoor.SetBool("isOpen", false);
        }

    }

}
