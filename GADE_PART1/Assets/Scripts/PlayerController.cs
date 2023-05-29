using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 21.03f; // sets move speed
    public float jumpForce = 10f; // sets jump force
    private bool isJumping = false; // checks if jumping
     // checks if grounded
    public float minX = -5f; // minimum x position
    public float maxX = 5f; // maximum x position
    public int Forward = 0; // forward move speed
    private float timeSincePickup = 0f; // variable for pickup
    public float forwardMoveSpeed = 5f; // new variable for forward movement speed
    public float customGravity = -19.62f; // sets custom gravity for player
    public float speedIncreaseRate = 0.1f;
    public float speedIncreaseDelay = 5f;
    private float timeSinceStart = 0f;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI TimePassed;
    public RawImage image; // Assign the RawImage in the Inspector
    public Animator animator;

    void FixedUpdate()
    {
        // Get the Rigidbody component attached to the player game object
        Rigidbody rb = GetComponent<Rigidbody>();

        // Add a custom gravity force to the Rigidbody component
        rb.AddForce(new Vector3(0, customGravity, 0));
    }

    private float timeSinceSpeedIncrease = 0f; // variable to keep track of time since speed increase started
    private bool speedIncreased = false; // variable to keep track of whether the speed has increased

    private bool canSpeedUp = true; // variable to control whether the player can speed up

    void Update()
    {
        timeSinceStart += Time.deltaTime;
        TimePassed.text = "Time Passed: " + timeSinceStart.ToString("F1");
        if (timeSinceStart >= speedIncreaseDelay && canSpeedUp)
        {
            // Set a maximum value for moveSpeed and forwardMoveSpeed
            float maxSpeed = 40f;
            moveSpeed = Mathf.Min(moveSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);
            forwardMoveSpeed = Mathf.Min(forwardMoveSpeed + speedIncreaseRate * Time.deltaTime, maxSpeed);

            // Set speedIncreased to true
            speedIncreased = true;
        }

        // Increase timeSinceSpeedIncrease if speed has increased
        if (speedIncreased)
        {
            timeSinceSpeedIncrease += Time.deltaTime;

            // Reset speed after 20 seconds have passed
            if (timeSinceSpeedIncrease >= 40f)
            {
                moveSpeed = 25f;
                forwardMoveSpeed = 5f;
                timeSinceSpeedIncrease = 0f;
                speedIncreased = false;
                canSpeedUp = false; // prevent the player from speeding up again
            }
        }
    
    


        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move player left or right
        transform.position += new Vector3(horizontalInput, 0, Forward) * Time.deltaTime * moveSpeed;

        // Move player forward
        transform.position += new Vector3(0, 0, Forward) * Time.deltaTime * forwardMoveSpeed;

        // Constrain player's movement on x-axis
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

        // Jump input
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            
            isJumping = true;
            animator = GetComponent<Animator>();
            

        }

        if (transform.position.y > 0.15)
        {
           animator.SetBool("isJumping", true);
            
        }

        if (transform.position.y < 0.15)
        {
            animator.SetBool("isJumping", false);
        }
        
    }




    void OnCollisionEnter(Collision collision) // checks if player is on the ground
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
            isJumping = false;
            if (isJumping == false)
            {
                animator.SetBool("isJumping", false);
            }
        }
    }

    void OnCollisionExit(Collision collision) // does a check if player leaves ground
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            
        }
    }

    

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flying"))
        {
            animator = GetComponent<Animator>();
            timeSincePickup = 0f;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.drag = 20f; // Set the linear drag
            rb.angularDrag = 20f; // Set the angular drag
            rb.useGravity = false; // disables players gravity
            float maxY = 7f; // Set the maximum y value here

            image.enabled = true; // Show the RawImage

            while (timeSincePickup < 10f)
            {
                animator.SetBool("isFlying", true);
                float targetY = Mathf.Lerp(transform.position.y, maxY, timeSincePickup / 7f); // moves to a position smoothly
                targetY = Mathf.Clamp(targetY, transform.position.y, maxY); // Clamp the targetY value
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z); // the actual moving of player
                
                timerText.text = "Time Remaining: " + (10 - timeSincePickup).ToString("F1");

                
                timeSincePickup += Time.deltaTime;
                
                yield return null;
            
            }
            animator.SetBool("isFlying", false);
            
            timerText.text= "";
            
            rb.useGravity = true; // enables players gravity
            rb.drag = 0f; // Set the linear drag to 0
            rb.angularDrag = 0f; // Set the angular drag to 0

            image.enabled = false; // Hide the RawImage
        }
    }
}
