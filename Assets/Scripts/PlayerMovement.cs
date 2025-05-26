using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public KeyCode leftKey;
    public KeyCode rightKey;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on the player!");
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        float moveInput = 0f;

        if (Input.GetKey(leftKey))
        {
            moveInput = -1f;
        }

        else if (Input.GetKey(rightKey))
        {
            moveInput = 1f;
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }
}