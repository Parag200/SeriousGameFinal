using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NicoNico : MonoBehaviour
{
    public PlayerMove playerMove;
    public bool touchNico = false;

    private void OnTriggerEnter(Collider other)
    {
        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.hasSeen3 == false)
        {
            touchNico = true;
            Debug.Log("STOP");
        }
    }
}
