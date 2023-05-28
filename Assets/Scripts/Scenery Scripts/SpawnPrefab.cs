using System.Collections;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;
    private float time = 0;
    public bool randomRotate = false;
    private float range = 0.15f;
    public bool randomTime = false;

    public bool isSpawning = true;
    public Animator anim;

    private void Start(){
    }
    
    private void Update(){
        if (anim != null){
            anim.SetBool("Active", isSpawning);
        }
        if (isSpawning){
            time += Time.deltaTime;
            if (time >= spawnInterval){
                time -= spawnInterval;
                if (randomTime){
                    time += Random.Range(-range,range);
                }
                if(!randomRotate){
                    Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
                }else{
                    Instantiate(prefabToSpawn, transform.position, Quaternion.Euler(0f, 0f, Random.Range(0f, 360f)));
                }
            }
        }
    }

    public void Disable(){
        isSpawning = false;
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.color = new Color(0,0,0,0.5f);
    }
    
    public void Enable(){
        isSpawning = true;
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.color = new Color(0,0,0,1f);
    }
}
