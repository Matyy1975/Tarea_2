using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour{
    public bool changeLocks;
    public bool changeSpeeds;
    public bool changeTarget;
    public bool Hlock;
    public bool Vlock;
    public float Hspeed;
    public float Vspeed;
    public Transform newTarget;
    private DefaultCamera cameraScript;
    public bool destructOnTrigger;
    public bool snapWhenTrigger;
    // Start is called before the first frame update
    void Start(){
        cameraScript = GameObject.Find("Main Camera").GetComponent<DefaultCamera>();
    }
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.tag == "Player"){
            if (changeSpeeds){
                cameraScript.horizontalSmoothSpeed = Hspeed;
                cameraScript.verticalSmoothSpeed = Vspeed;
            }
            if (changeLocks){
                cameraScript.freezeHorizontal = Hlock;
                cameraScript.freezeVertical = Vlock;
            }
            if (changeTarget){
                cameraScript.target = newTarget;
            }
            if (snapWhenTrigger){
                cameraScript.gameObject.transform.position = new Vector3(cameraScript.target.position.x,cameraScript.target.position.y,-10);
            }
            if (destructOnTrigger){
                Destroy(gameObject);
            }
        }
    }
}