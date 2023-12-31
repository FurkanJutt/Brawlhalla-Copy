﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    [Header("Jump")]
    public float jumpForce = 5f;
    private int maxJumps = 2;
    private int jumpCount = 0;
    private bool isGrounded = false;

    [Header("Weapon")]
    public GameObject weaponHolder;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void Jump()
    {
        if (isGrounded && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
        if(jumpCount == maxJumps)
        {
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log($"{GetType().Name} collided with ground");
            isGrounded = true;
            jumpCount = 0;
        }
    }

    
}