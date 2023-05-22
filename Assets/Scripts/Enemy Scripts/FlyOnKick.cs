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
    private bool tagsToChange = false;
    private int ignoreCollisionFrames = 2;
    // Start is called before the first frame update
    void Start(){
        //get your own rigidbody into rb
        rb = GetComponent<Rigidbody2D>();
        backupGrav = rb.gravityScale;
    }

    // Update is called once per frame
    void Update(){
        if (rb.gravityScale == 0){
            ignoreCollisionFrames -= 1;
        }
        //change tag back to enemy so player gets hurt
        if (tagsToChange) {
            gameObject.tag = "Enemy";
            gameObject.layer = LayerMask.NameToLayer("Enemies");
            tagsToChange = false;
            Destroy(gameObject,0.04f);
        }
    }

    //used to restore the object's gravity when it collides with anything
    void OnCollisionEnter2D (Collision2D other){
        if ((rb.gravityScale == 0)&&(ignoreCollisionFrames<=0)){
            rb.gravityScale = backupGrav;
            //Set to change the tags next frame
            tagsToChange = true;
            ignoreCollisionFrames = 2;
        }
    }
    
    //Called when DetectKick decides that it has been kicked by the player
    public void Execute(){
        if (!prevent) {
            //Change the tag to projectile so enemies get hurt (and layer, cuz' unity is silly)
            gameObject.tag = "Projectile";
            gameObject.layer = LayerMask.NameToLayer("Projectiles");
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
