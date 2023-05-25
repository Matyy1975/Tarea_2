using System.Collections;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;
    private float time = 0;

    public bool isSpawning = true;

    private void Start(){
    }
    
    private void Update(){
        if (isSpawning){
            time += Time.deltaTime;
            if (time >= spawnInterval){
                time -= spawnInterval;
                Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
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
