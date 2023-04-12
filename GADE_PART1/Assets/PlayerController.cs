using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private bool isGrounded = false;
    public float minX = -5f; // minimum x position
    public float maxX = 5f; // maximum x position
    public int Forward = 0;
    private float timeSincePickup = 0f;

    void Update()
    {
        // Get horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");

        // Move player left or right
        transform.position += new Vector3(horizontalInput, 0, Forward) * Time.deltaTime * moveSpeed;

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

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flying"))
        {
            timeSincePickup = 0f;
            timeSincePickup += Time.deltaTime;
            while (timeSincePickup < 5f)
            {
                transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), 5, transform.position.z);
            }

            timeSincePickup = 0f;

        }
    }*/
}
