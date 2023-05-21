using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickCollision : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }    
    //if the collided object has a kick detector, then trigger it.
    private void OnTriggerEnter2D(Collider2D other){
        DetectKick detectorScript = other.gameObject.GetComponent<DetectKick>();
        if (detectorScript != null){
            detectorScript.Kicked();
        }
    }
}
