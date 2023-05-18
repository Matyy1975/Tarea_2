using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float stompMaxTime = 0.5f; //ammount of time the stomp influence circle will remain active for
    public float instaDropFreezeTime = 1f;
    public GameObject childObject; // Objeto hijo cuyo SpriteRenderer se modificara
    public GameObject stompInfluence;

    private bool airborne = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private float freezeTime = 0f;
    private float stompTime = 0f;
    private bool facingRight = true; //might sound obvious but when facingRight false, then we're facing Left

    //Teclas
    public KeyCode instantDropKey = KeyCode.S;
    public KeyCode kickKey = KeyCode.Z;

    //Vars used by other scripts
    //stomped is used by StompStore to store all the enemies that reacted to the player's stomp. This is so the player can kick them later.
    [HideInInspector]
    public List<GameObject> stomped;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        sr = childObject.GetComponent<SpriteRenderer>();
        stomped = new List<GameObject>();
    }

    void Update(){
        //disable the stomp influence gameobject
        if (stompTime > 0){
            stompTime -= Time.deltaTime;
            if (stompTime <= 0){
                stompInfluence.SetActive(false);
            }
        }
        //We fetch the input here so the player can flip even while frozen
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0){
            facingRight = false;
        }else if (horizontalInput > 0){
            facingRight = true;
        }
        //Change the scale depending on where we're facing
        //Putting it here instead of where it changes allows us more modularity in the code
        if (facingRight){
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }else{
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (freezeTime > 0){
            //Freeze movement if we've just insta-dropped
            freezeTime -= Time.deltaTime;
            //flush the list of stomped enemies when the player becomes able to move again
            if (freezeTime <= 0){ 
                //return the sprite to original color (again, for Debug Purposes)
                sr.color = Color.white;
                stomped.Clear();
            }
        }else{
            // Movimiento horizontal
            rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
            // Salto
            if (Input.GetButtonDown("Jump") && !airborne){
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                airborne = true;
            }
            // Instant drop
            if (Input.GetKeyDown(instantDropKey) && airborne){
                InstantDrop();
            }
        }
        //Check if we've kicked
        if (Input.GetKeyDown(kickKey)){
            Kick();
        }
    }

    void OnCollisionStay2D(Collision2D collision){
        //Ground here just means game Terrain, as in, not enemies or other elements. could be walls
        if (collision.gameObject.CompareTag("Ground")){
            if (Mathf.Abs(collision.contacts[0].normal.y) < 0.1f){
                // If the collision is with a wall, set the player as airborne
                airborne = true;
            }else{
                airborne = false;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            airborne = true;
        }
    }

    void InstantDrop(){
        // Cast a ray down to check for the ground below the player
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
        // Check if the ray hit anything
        if (hit.collider != null){
            // Move the player to the closest ground position
            transform.position = new Vector3(transform.position.x, hit.point.y + GetComponent<BoxCollider2D>().size.y / 2f, transform.position.z);
            // Kill all velocity and forces acting on Player
            rb.velocity = Vector2.zero;
            rb.Sleep();
            freezeTime = instaDropFreezeTime;
            //make the sprite yellow, just for debug purposes
            sr.color = Color.yellow;
            stompInfluence.SetActive(true);
            stompTime = stompMaxTime;
        }
    }

    //I'll have to rework this WHOLE FUCKING FUNCTION KILL ME AAAAAAAA
    void Kick(){
        Debug.Log("Happened");
        for(int i=0 ; i<stomped.Count ; i++) {
            //Iterate through every stomped object
            //First, determine if the player is facing them (the extra kicked variable is just for readability)
            bool kicked = false;
            if ((facingRight && (transform.position.x < stomped[i].transform.position.x)) || (!facingRight && (transform.position.x > stomped[i].transform.position.x))){
                kicked = true;
            }
            //if so, then send the signal that they've been kicked
            if (kicked) {
                DetectKick detectorScript = stomped[i].GetComponent<DetectKick>();
                detectorScript.Kicked();
            }
        }
        //flush the stored detected stomps to prevent multiple kicks
        stomped.Clear();
        //immediately unfreeze the player
    }
}