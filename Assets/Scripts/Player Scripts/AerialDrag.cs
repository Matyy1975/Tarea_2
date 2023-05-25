using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AerialDrag : MonoBehaviour{
    public float airDrag = 0f;
    public float groundDrag = 1f; 
    
    private Rigidbody2D rb;
    private PlayerController playerScript;
    // Start is called before the first frame update
    void Start(){
        //Hooks into the player controller to check whether airborne or not
        playerScript = GetComponent<PlayerController>();
        //needs the rigidBody to change the linear drag
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (playerScript.airborne){
            rb.drag = airDrag;
        }else{
            rb.drag = groundDrag;
        }
    }
}
