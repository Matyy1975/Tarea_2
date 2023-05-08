using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody2D rb;
    public GameObject childObject; // Objeto hijo cuyo SpriteRenderer se modificará

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput, 0, 0) * Time.deltaTime * moveSpeed;

        // Flip sprite renderer del objeto hijo
        SpriteRenderer sr = childObject.GetComponent<SpriteRenderer>();
        if (horizontalInput < 0)
        {
            sr.flipX = true;
        }
        else if (horizontalInput > 0)
        {
            sr.flipX = false;
        }

        // Salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}