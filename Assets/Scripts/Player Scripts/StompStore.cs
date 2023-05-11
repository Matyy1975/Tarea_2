using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The purpose of this script is for the player to be able to remember all the enemies that were affected by the stomp the player does
public class StompStore : MonoBehaviour{
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log(other.name);
    }
}
