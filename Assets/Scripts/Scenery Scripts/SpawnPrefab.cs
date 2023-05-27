using System.Collections;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;
    private float time = 0;
    public bool randomRotate = false;

    public bool isSpawning = true;

    private void Start(){
    }
    
    private void Update(){
        if (isSpawning){
            time += Time.deltaTime;
            if (time >= spawnInterval){
                time -= spawnInterval;
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
