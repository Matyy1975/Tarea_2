using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieOnTag : MonoBehaviour{
    public string tagToKill;
    void Start(){
        
    }
    
    void Update(){
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(tagToKill)){
            Destroy(gameObject,.04f);
        }
    }
}
