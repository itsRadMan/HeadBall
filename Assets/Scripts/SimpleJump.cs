using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleJump : MonoBehaviour
{
    public float jumpForce = 10f;
    public KeyCode jumpKey = KeyCode.Space;
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    public bool isGrounded;
    private bool jumpRequested;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (groundCheckPoint == null)
        {
            return;
        }

        if (Input.GetKeyDown(jumpKey))
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (rb == null || groundCheckPoint == null) return;

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);

        if (isGrounded && jumpRequested)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        jumpRequested = false;
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheckPoint.position, groundCheckRadius);
        }
    }
}