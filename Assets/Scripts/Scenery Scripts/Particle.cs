using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour{
    public float life = 1f;
    public bool shrink = true;
    private float maxLife;
    private SpriteRenderer sr;
    private Vector3 startScale;
    public float startAlpha = 1f;
    // Start is called before the first frame update
    void Start(){
        maxLife = life;
        sr = GetComponent<SpriteRenderer>();
        startScale = transform.localScale;
    }

    // Update is called once per frame
    void Update(){
        life -= Time.deltaTime;
        float normalizedLife = 1-(life/maxLife);
        sr.color = new Color(1,1,1,Mathf.Lerp(startAlpha,0f,normalizedLife));
        if (shrink){
            float scaleX = Mathf.Lerp(startScale.x, 0f, normalizedLife);
            float scaleY = Mathf.Lerp(startScale.y, 0f, normalizedLife);
            transform.localScale = new Vector3(scaleX,scaleY,transform.localScale.z);
        }
        if (life <= 0){
            Destroy(gameObject);
        }
    }
}
