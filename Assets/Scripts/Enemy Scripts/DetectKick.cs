using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectKick : MonoBehaviour{
    //This script is only to listen to the player's Kick, and execute any other script the enemy may have that will react to such.
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update(){
    }
    
    //When the player 'kicks' this GameObject, this'll be what decides which script to execute. (The intermediary is there so I can execute *different* scripts, without having to cast them all to a method (which I barely understand how to do))
    public void Kicked(){
        FlyOnKick kickScript = gameObject.GetComponent<FlyOnKick>();
        if (kickScript != null){
            kickScript.Execute();
        }
    }
}
