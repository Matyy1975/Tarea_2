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
    
    public void Kicked(){
        Debug.Log(gameObject.name + " has been kicked!");
    }
}
