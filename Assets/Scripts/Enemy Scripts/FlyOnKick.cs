using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOnKick : MonoBehaviour{
    public GameObject aimerObject;
    public float kickForce = 3f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start(){
        //get your own rigidbody into rb
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        
    }
    //Called when DetectKick decides that it has been kicked by the player
    public void Execute(){
        //Get Zrotation from the aimer child gameobject
        Vector2 directionVect = aimerObject.transform.up.normalized;
        Vector2 forceVect = directionVect * kickForce;
        rb.velocity = Vector3.zero;
        rb.AddForce(forceVect, ForceMode2D.Impulse);
        aimerObject.SetActive(false);
    }
}
