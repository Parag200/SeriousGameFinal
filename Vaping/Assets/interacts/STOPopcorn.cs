using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STOPopcorn : MonoBehaviour
{
    public bool touchPOP = false;
    public PlayerMove playerMove;

    
    private void OnTriggerEnter(Collider other)
    {
        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.hasSeen==false)
        {
            touchPOP = true;
            Debug.Log("STOP");
        }
    }
}
