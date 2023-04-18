using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isJumping = false;
    private bool isGrounded = false;
    public float minX = -5f; // minimum x position
    public float maxX = 5f; // maximum x position
    public int Forward = 0;
    private float timeSincePickup = 0f;
    public float forwardMoveSpeed = 5f; // new variable for forward movement speed
    public float customGravity = -19.62f;

    void FixedUpdate()
    {
        // Get the Rigidbody component attached to the player game object
        Rigidbody rb = GetComponent<Rigidbody>();

        // Add a custom gravity force to the Rigidbody component
        rb.AddForce(new Vector3(0, customGravity, 0));
    }
    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Change the moveSpeed value to adjust the horizontal movement speed
        moveSpeed = 20f;

        // Move player left or right
        transform.position += new Vector3(horizontalInput, 0, Forward) * Time.deltaTime * moveSpeed;

        // Move player forward
        transform.position += new Vector3(0, 0, Forward) * Time.deltaTime * forwardMoveSpeed;

        // Constrain player's movement on x-axis
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);

        // Jump
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isJumping = true;
        }
    
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumping = false;
        }
        
        
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flying"))
        {
            float timeSincePickup = 0f;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.drag = 20f; // Set the linear drag
            rb.angularDrag = 20f; // Set the angular drag
            rb.useGravity = false;
            float maxY = 7f; // Set the maximum y value here
            
            while (timeSincePickup < 10f)
            {
                float targetY = Mathf.Lerp(transform.position.y, maxY, timeSincePickup / 7f);
                targetY = Mathf.Clamp(targetY, transform.position.y, maxY); // Clamp the targetY value
                transform.position = new Vector3(transform.position.x, targetY, transform.position.z);
                timeSincePickup += Time.deltaTime;
                yield return null;
            }
            rb.useGravity = true;
            rb.drag = 0f; // Set the linear drag
            rb.angularDrag = 0f;
        }
    }
}
