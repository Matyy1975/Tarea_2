using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float stompMaxTime = 0.5f; //ammount of time the stomp influence circle will remain active for
    public float instaDropFreezeTime = 1f;
    public GameObject childObject; // Objeto hijo cuyo SpriteRenderer se modificara
    public GameObject stompInfluence;
    
    private bool isJumping = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float freezeTime = 0f;
    private float stompTime = 0f;
    
    //Teclas
    public KeyCode instantDropKey = KeyCode.S;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        sr = childObject.GetComponent<SpriteRenderer>();
    }

    void Update(){
        //disable the stomp influence gameobject
        if (stompTime > 0){
            stompTime -= Time.deltaTime;
            if (stompTime <= 0){
                stompInfluence.SetActive(false);
            }
        }
        if (freezeTime > 0){
            //Freeze movement if we've just insta-dropped
            freezeTime -= Time.deltaTime;
        }else{
            // Movimiento horizontal
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            // Flip sprite renderer del objeto hijo
            if (horizontalInput < 0){
                sr.flipX = true;
            }
            else if (horizontalInput > 0){
                sr.flipX = false;
            }
            // Salto
            if (Input.GetButtonDown("Jump") && !isJumping){
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
            // Instant drop
            if (Input.GetKeyDown(instantDropKey)){
                InstantDrop();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }

    void InstantDrop(){
        // Cast a ray down to check for the ground below the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        // Check if the ray hit anything
        if (hit.collider != null){
            // Move the player to the closest ground position
            transform.position = new Vector3(transform.position.x, hit.point.y + GetComponent<BoxCollider2D>().size.y/2f, transform.position.z);
            // Kill all velocity and forces acting on Player
            rb.velocity = Vector2.zero;
            rb.Sleep();
            freezeTime = instaDropFreezeTime;
            stompInfluence.SetActive(true);
            stompTime = stompMaxTime;
        }
    }
}