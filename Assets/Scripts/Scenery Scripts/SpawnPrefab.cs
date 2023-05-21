using System.Collections;
using UnityEngine;

public class SpawnPrefab : MonoBehaviour{
    public GameObject prefabToSpawn;
    public float spawnInterval = 2f;

    private bool isSpawning = true;

    private void Start(){
        StartCoroutine(SpawnPrefabRepeatedly());
    }

    private IEnumerator SpawnPrefabRepeatedly(){
        while (isSpawning){
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
    }

    public void Disable(){
        isSpawning = false;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(0,0,0,0.5f);
    }
}
