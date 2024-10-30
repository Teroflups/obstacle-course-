using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Move : MonoBehaviour
{
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private bool doubleJump = false;
    [SerializeField] private LayerMask layerGround;
    private Rigidbody2D rb;
    private bool ground;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float overlapRadius;
    [SerializeField] private bool doubleJumpIsTrue;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Movement();
        Jump();
        CheckGround();
    }

    private void Movement()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(jumpKey) && ground)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            doubleJump = true;
        }
        else if (Input.GetKeyDown(jumpKey) && doubleJump && doubleJumpIsTrue)
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            doubleJump = false;
        }

    }

    private void CheckGround()
    {
        ground = Physics2D.OverlapCircle(groundCheck.position, overlapRadius, layerGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, overlapRadius);
    }

}

