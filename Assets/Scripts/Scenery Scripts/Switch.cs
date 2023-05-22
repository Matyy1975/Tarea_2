using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour{
    public string activateTag;
    public GameObject toAction;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    //What happens when the switch is pressed
    void activate(){
        SpawnPrefab spawnerScript = toAction.GetComponent<SpawnPrefab>();
        if (spawnerScript != null) {
            if (spawnerScript.isSpawning){
                spawnerScript.Disable();
            }else{
                spawnerScript.Enable();
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag(activateTag)){
            activate();
        }
    }
}
