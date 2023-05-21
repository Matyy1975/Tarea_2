using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kill parent on collision with object with a specific tag, to be clear.
public class KillParentOnTag : MonoBehaviour{
    public string tagToKill;
    public GameObject parent;
    void Start(){
        
    }
    
    void Update(){
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag(tagToKill)){
            Destroy(parent,.04f);
        }
    }
}
