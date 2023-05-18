using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyOnKick : MonoBehaviour{
    public GameObject aimerObject;
    public float kickForce = 3f;
    private Rigidbody2D rb;
    private float backupGrav;
    [HideInInspector]
    public bool prevent;
    // Start is called before the first frame update
    void Start(){
        //get your own rigidbody into rb
        rb = GetComponent<Rigidbody2D>();
        backupGrav = rb.gravityScale;
    }

    // Update is called once per frame
    void Update(){
        
    }
    
    //used to restore the object's gravity when it collides with anything
    void OnCollisionEnter2D (){
        if (rb.gravityScale == 0){
            rb.gravityScale = backupGrav;
            //Change the tag back to enemy so player gets hurt
            gameObject.tag = "Enemy";
        }
    }
    
    //Called when DetectKick decides that it has been kicked by the player
    public void Execute(){
        if (!prevent) {
            //Change the tag to projectile so enemies get hurt
            gameObject.tag = "Projectile";
            //Get Zrotation from the aimer child gameobject
            Vector2 directionVect = aimerObject.transform.up.normalized;
            Vector2 forceVect = directionVect * kickForce;
            //nullify all forces, then apply a force in that direction.
            rb.velocity = Vector3.zero;
            rb.AddForce(forceVect, ForceMode2D.Impulse);
            aimerObject.SetActive(false);
            //disable gravity so it flies in a straight line (and make sure to store a backup)
            backupGrav = rb.gravityScale;
            rb.gravityScale = 0;
        }
    }
}
