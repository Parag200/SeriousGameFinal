using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = -9.81f;

    public bool hasSeen = false;
    public bool hasSeen2 = false;
    public bool hasSeen3 = false;
    public bool hasSeen4 = false;
    public bool hasSeen5 = false;
    public bool hasSeen6 = false;
    public bool hasSeen7 = false;
    public bool notStuck = true;

    //texts
    public GameObject textBox;
    public GameObject textBox2;
    public GameObject textBox3;
    public GameObject textBox4;
    public GameObject textBox5;
    public GameObject Final;


    public GameObject notest;
    public GameObject test;

    public GameObject Q2;
    public GameObject Q3;
    public GameObject Q4;
    public GameObject Q5;


    public bool playerMove;

    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 350f;

    private CharacterController characterController;
    private Vector3 velocity;
    private float xRotation = 0f;

    [Header("References")]
    public Transform playerCamera;

    //scripts
    public STOPopcorn STOPopcorn;
    public TestTubes TestTubes;
    public NicoNico NicoNico;
    public FruitBowl FruitBowl;
    public Heart Heart;
    public Teach Teach;

    public int x = 0;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = true;
        textBox.SetActive(false);
        textBox2.SetActive(false);
        textBox3.SetActive(false);
        textBox4.SetActive(false);
        textBox5.SetActive(false);
        notest.SetActive(false);
        test.SetActive(false);
        Q2.SetActive(false);
        Q3.SetActive(false);
        Q4.SetActive(false);
        Q5.SetActive(false);
        Final.SetActive(false);
        characterController = GetComponent<CharacterController>();
        if (playerCamera == null)
        {
            Debug.LogError("No camera assigned to the player! Please assign a camera.");
            enabled = false;
            return;
        }

       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove==true)
        {
            HandleMouseLook();
            HandleMovement();
            Cursor.visible = false;
        }

        if (STOPopcorn.touchPOP==true && hasSeen == false)
        {
           
            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            textBox.SetActive(true);
            notStuck = false;
            x = x + 1;


        }

        if (TestTubes.touchTest == true && hasSeen2 == false)
        {

            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            textBox2.SetActive(true);
            notStuck = false;
            x = x + 1;


        }

        if (NicoNico.touchNico == true && hasSeen3 == false)
        {

            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            textBox3.SetActive(true);
            notStuck = false;
            x = x + 1;


        }

        if (Heart.touchHeart == true && hasSeen4 == false)
        {

            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            textBox5.SetActive(true);
            notStuck = false;
            x = x + 1;


        }

        if (FruitBowl.touchFruit == true && hasSeen5 == false)
        {

            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            textBox4.SetActive(true);
            notStuck = false;
            x = x + 1 ;


        }


        if (Teach.testTime==true && hasSeen7 == false)
        {
            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            test.SetActive(true);
            notStuck = false;
        }

        if (Teach.NOtestTime == true && hasSeen6==false)
        {
            characterController.Move(velocity * Time.deltaTime);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerMove = false;
            Cursor.visible = true;
            notest.SetActive(true);
            notStuck = false;
        }

        // Lock the cursor to the center of the screen
        if (notStuck == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            
        }

        if (notStuck == false)
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    private void HandleMouseLook()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player on the Y-axis (horizontal look)
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera on the X-axis (vertical look)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp vertical rotation
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    private void HandleMovement()
    {
        // Get input for movement
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Calculate movement direction relative to the player
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Apply gravity
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small downward force to keep grounded
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

        // Jump
        if (Input.GetButtonDown("Jump") && characterController.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * gravity);
        }

    
    }

    public void Exit()
    {
        if (STOPopcorn.touchPOP == true)
        {
            hasSeen = true;
        }

        if (TestTubes.touchTest == true)
        {
            hasSeen2 = true;
        }

        if (NicoNico.touchNico == true)
        {
            hasSeen3 = true;
        }

        if (Heart.touchHeart == true)
        {
            hasSeen4 = true;
        }

        if (FruitBowl.touchFruit==true)
        {
            hasSeen5 = true;
        }


        if (Teach.NOtestTime == true)
        {
            hasSeen6 = true;
        }


        if (Teach.testTime == true)
        {
            hasSeen7 = true;
        }




        textBox.SetActive(false);
        textBox2.SetActive(false);
        textBox3.SetActive(false);
        textBox4.SetActive(false);
        textBox5.SetActive(false);
        notest.SetActive(false);
        notStuck = true;
        playerMove = true;
    }


    public void Q1True()
    {
        score++;
        Q2.SetActive(true);
    }
    public void Q1False()
    {
        score = score + 0;
        Q2.SetActive(true);
    }

    public void Q2True()
    {
        score++;
        Q3.SetActive(true);
    }
    public void Q2False()
    {
        score = score + 0;
        Q3.SetActive(true);
    }

    public void Q3True()
    {
        score++;
        Q4.SetActive(true);
    }
    public void Q3False()
    {
        score = score + 0;
        Q4.SetActive(true);
    }

    public void Q4True()
    {
        score++;
        Q5.SetActive(true);
    }
    public void Q4False()
    {
        score = score + 0;
        Q5.SetActive(true);
    }


    public void FinalTrue()
    {
        score++;
        Final.SetActive(true);

    }
    public void FinalFalse()
    {
        score = score + 0;
        Final.SetActive(true);

    }
}
