using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTag : MonoBehaviour{
    public string tagToKill;
    public int timesToBeHit = 1;
    void Start(){
        
    }
    
    void Update(){
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(tagToKill)){
            timesToBeHit -= 1;
            if (timesToBeHit == 0){
                Destroy(gameObject);
            }
        }
    }
}
