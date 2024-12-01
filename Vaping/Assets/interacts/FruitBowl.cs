using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBowl : MonoBehaviour
{
    public PlayerMove playerMove;
    public bool touchFruit = false;

    private void OnTriggerEnter(Collider other)
    {
        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.hasSeen5 == false)
        {
            touchFruit = true;
            Debug.Log("STOP");
        }
    }
}
