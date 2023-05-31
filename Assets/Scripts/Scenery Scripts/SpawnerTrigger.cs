using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerTrigger : MonoBehaviour{
    public SpawnPrefab spawnScript;
    public bool activate;
    // Start is called before the first frame update
    void Start(){
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            if (activate){
                spawnScript.Enable();
            }else{
                spawnScript.Disable();
            }
        }
    }
}