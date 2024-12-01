using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTubes : MonoBehaviour
{
    public bool touchTest = false;
    public PlayerMove playerMove;


    private void OnTriggerEnter(Collider other)
    {
        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.hasSeen2 == false)
        {
            touchTest = true;
            Debug.Log("STOP");
        }
    }
}
