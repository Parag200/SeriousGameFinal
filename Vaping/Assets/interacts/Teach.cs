using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teach : MonoBehaviour
{
    public bool testTime = false;
    public bool NOtestTime = false;
    public PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.x >= 4)
        {
            testTime = true;
        }

        // Corrected the CompareTag syntax
        if (other.gameObject.CompareTag("Player") && playerMove.x < 5)
        {
            NOtestTime = true;
        }
    }
}
