using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAim : MonoBehaviour{
    public float minAngle = 0f;
    public float maxAngle = 90f;
    private float startVelocity = -1f;
    private float startAngle;
    private float endAngle;
    private float currentVelocity;
    private Rigidbody2D rb;
    private float angle;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void FixedUpdate(){
        if (startVelocity != -1f){
            currentVelocity = rb.velocity.y;
            //Absolute Value that velocity!
            if (currentVelocity < 0){
                currentVelocity = -currentVelocity;
            }
            // Calculate the progress towards reaching the maximum velocity
            float progress = Mathf.Clamp01(currentVelocity / startVelocity);
            // Interpolate between the startAngle and endAngle based on the progress (friendship ended with rule of threes, now lerp is my best friend)
            angle = Mathf.Lerp(startAngle, endAngle, progress);
            transform.rotation = Quaternion.Euler(0f,0f,angle);
        }
    }
    //When the aimer is enabled...
    void OnEnable(){
        //Get the total upward velocity. this'll be the maximum that defines the -90 angle (rightwards)
        rb = transform.parent.gameObject.GetComponent<Rigidbody2D>();
        startVelocity = rb.velocity.y;
        //check if player is to the left or right. Adjust the angle accordingly.
        Transform playerTrans = GameObject.Find("Player").transform;
        if (playerTrans.position.x > transform.position.x){
            startAngle = maxAngle;
            endAngle = minAngle;
        }else{
            startAngle = -maxAngle;
            endAngle = -minAngle;
        }
        angle = startAngle;
        currentVelocity = startVelocity;
        //The current Velocity's absolute value is what we will use to calculate the angle here (must range from -90 to 0)
    }
    //Reset a variables to null to prime for a future calculation (just in case)
    void OnDisable(){
        startVelocity = -1f;
        startAngle = -1f;
        endAngle = -1f;
    }
}