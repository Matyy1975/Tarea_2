using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAim : MonoBehaviour{
    private float startVelocity = -1f;
    private float currentVelocity;
    private Rigidbody2D rb;
    private float angle;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (startVelocity != -1f){
            currentVelocity = rb.velocity.y;
            //Absolute Value that velocity!
            if (currentVelocity < 0){
                currentVelocity = -currentVelocity;
            }
            //the angle must be proportional to current velocity (rule of threes)
            angle = -((90 * currentVelocity)/startVelocity);
            transform.rotation = Quaternion.Euler(0f,0f,angle);
        }
    }
    //When the aimer is enabled...
    void OnEnable(){
        //Get the total upward velocity. this'll be the maximum that defines the -90 angle (rightwards)
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        startVelocity = rb.velocity.y;
        angle = -90f;
        currentVelocity = startVelocity;
        //The startVelocity's absolute value is what we use to calculate the angle here (must range from -90 to 0)
    }
    //Reset a variables to null to prime for a future calculation (just in case)
    void OnDisable(){
        startVelocity = -1f;
    }
}