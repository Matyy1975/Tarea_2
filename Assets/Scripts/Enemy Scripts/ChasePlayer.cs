using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{ 
    public float speed = 1f;
    private bool facingRight = true;
    private GameObject player;
    private Rigidbody2D rb;
    [HideInInspector]
    public bool freeze = false;
    private float freezeTime = -1f;
    public float maxFreezeTime = 1f;
    // Start is called before the first frame update
    void Start(){
        //Find the player GameObject
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if ((!freeze)&&(player != null)){
            //First thing: find out whether the player is to the left or the right of you.
            if (player.transform.position.x < transform.position.x){
                facingRight = false;
            }else{
                facingRight = true;
            }
            //Change the scale depending on where we're facing
            //Putting it here instead of where it changes allows us more modularity in the code
            float direction; //-1 or 1 depending on whether we're facing left or right
            if (facingRight){
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direction = 1;
            }
            else{
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                direction = -1;
            }
            //Slowly Creep towards the player
            rb.velocity = new Vector2(direction * speed, rb.velocity.y);
        }else if(freezeTime == -1f){
            rb.velocity = new Vector2(0, rb.velocity.y);
            freezeTime = maxFreezeTime;
        }else{
            freezeTime = freezeTime - Time.deltaTime;
            if (freezeTime <= 0){
                freezeTime = -1;
                freeze = false;
            }
        }
    }
}
