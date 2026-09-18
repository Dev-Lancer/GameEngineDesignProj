using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rBody;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public float speed = 7.0f, jumpPow = 16.0f;
    private float hori;
    private bool isFaceRight = true;
    private bool jumpRequested = false;
    private bool jumpCutRequested = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // left and right
        hori = Input.GetAxisRaw("Horizontal");

        // up
        // read input here, apply physics in FixedUpdate
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpRequested = true;
        }

        // short hop when releasing space
        if (Input.GetKeyUp(KeyCode.Space) && rBody.linearVelocity.y > 0.0f)
        {
            jumpCutRequested = true;
        }

        Flip();
    }

    private void FixedUpdate()
    {
        // horizontal movement
        rBody.linearVelocity = new Vector2(hori * speed, rBody.linearVelocity.y);

        // apply jump request from Update
        if (jumpRequested)
        {
            rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, jumpPow);
            jumpRequested = false;
        }

        // apply jump cut (short hop)
        if (jumpCutRequested)
        {
            if (rBody.linearVelocity.y > 0.0f)
                rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, rBody.linearVelocity.y * 0.5f);
            jumpCutRequested = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("breadcrumb") || collision.CompareTag("Sandwich"))
        {
            Destroy(collision.gameObject);
        }

        if(collision.CompareTag("Enemy") || (collision.CompareTag("Void")))
        {
            // Handle player death or respawn logic here
            Debug.Log("Player has died!");
        }
    }

    private void Flip()
    {
        if (isFaceRight && hori < 0.0f || !isFaceRight && hori > 0.0f)
        {
            isFaceRight = !isFaceRight;

            // flip by turning the scale negative
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;

            transform.localScale = localScale;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
