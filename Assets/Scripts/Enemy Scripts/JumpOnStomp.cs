using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOnStomp : MonoBehaviour{
    public float jumpForce = 5f;
    
    private Rigidbody2D rb;
    private ChasePlayer moveScript;
    private bool isJumping = true;
    // Start is called before the first frame update
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<ChasePlayer>();
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
            moveScript.freeze = true;
            //find and enable aimer child gameobject that'll rotate to define the angle of the kick
            GameObject aimer = transform.Find("Aimer").gameObject;
            aimer.SetActive(true);
            FlyOnKick KickScript = GetComponent<FlyOnKick>();
            KickScript.prevent = false;
        }
        else{
            //if we have NOT bounced up as a result of the stomp, change a var to prevent you from being kicked
            FlyOnKick KickScript = GetComponent<FlyOnKick>();
            KickScript.prevent = true;
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision){
        //Check if jumping to prevent doublejumps later
        if (collision.gameObject.CompareTag("Ground")){
            if ((Mathf.Abs(collision.contacts[0].normal.y) >= 0.1f) && (collision.contacts[0].point.y < transform.position.y)){
                isJumping = false;
                moveScript.freeze = false;
                moveScript.freezeTime = -1f;
                GameObject aimer = transform.Find("Aimer").gameObject;
                aimer.SetActive(false);
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        //Check if jumping to prevent doublejumps later
        if (collision.gameObject.CompareTag("Ground")){
            isJumping = true;
        }
    }
}
