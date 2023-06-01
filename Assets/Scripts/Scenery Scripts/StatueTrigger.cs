using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatueTrigger : MonoBehaviour{
    public ChasePlayer chaseScript;
    public bool activate;
    // Start is called before the first frame update
    void Start(){
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            if (activate){
                chaseScript.speed = 1f;
            }else{
                chaseScript.speed = 0f;
            }
        }
    }
}