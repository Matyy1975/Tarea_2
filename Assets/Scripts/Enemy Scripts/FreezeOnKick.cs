using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeOnKick : MonoBehaviour{
    private ChasePlayer chaseScript;
    // Start is called before the first frame update
    void Start(){
        //This one hooks onto the ChasePlayer script
        chaseScript = GetComponent<ChasePlayer>();
    }

    // Update is called once per frame
    void Update(){

    }
    //Called when DetectKick decides that it has been kicked by the player
    public void Execute(){
        if (chaseScript != null){
            chaseScript.freeze = true;
        }
    }
}
