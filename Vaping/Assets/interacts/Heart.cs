using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public PlayerMove playerMove;
    public bool touchHeart = false;

    private void OnTriggerEnter(Collider other)
    {
        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.hasSeen4 == false)
        {
            touchHeart = true;
            Debug.Log("STOP");
        }
    }
}
