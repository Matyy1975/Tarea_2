using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnDestroy : MonoBehaviour{
    public GameObject prefabToInstantiate;

    private void OnDestroy(){
        if(gameObject.scene.isLoaded){
            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);
        }
    }
}
