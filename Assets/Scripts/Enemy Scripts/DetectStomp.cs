using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectStomp : MonoBehaviour{
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update(){
    }
    
    void OnTriggerEnter2D(Collider2D other){
        //Detect if the player has stomped near it
        if (other.gameObject.CompareTag("Stomp")){
            //find if the object has a reaction to the stomp and execute if so
            JumpOnStomp stompScript = GetComponent<JumpOnStomp>();
            if (stompScript != null){
                stompScript.Stomped();
            }
        }
    }
}
