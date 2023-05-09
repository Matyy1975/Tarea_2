using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnStomp : MonoBehaviour{
    public float jumpForce = 5f;
    
    private Rigidbody2D rb;
    private bool isJumping = true;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    //When the stomp is detected nearby
    public void Stomped(){
        //prevent bounce up when already airborne
        if (!isJumping){
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        //Check if jumping to prevent doublejumps later
        if (collision.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }
}
