using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour{
    private SceneLoader loadScript;
    public string activateTag;
    // Start is called before the first frame update
    void Start(){
        loadScript = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.CompareTag(activateTag)){
            loadScript.LoadScene();
        }
    }
}
