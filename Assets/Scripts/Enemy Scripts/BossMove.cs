using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour{
    public Transform Point1;
    public Transform Point2;
    public float timeTaken = 1f;
    private float lerpTime = 0f;
    public int loops = 1;
    private int currentLoop = 0;
    private bool increasing = true;
    public float freezeTime = 3f;
    private float freeze = 0f;
    public float hurtTime = 1f;
    [HideInInspector]
    public float currentHurtTime = -1f;
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){
        if(currentHurtTime <= 0) { 
            if (freeze == 0f){
                if (((lerpTime <= 1)&&increasing)||((lerpTime >= 0)&&!increasing)){
                    if (increasing){
                        lerpTime += Time.deltaTime/timeTaken;
                    }else{
                        lerpTime -= Time.deltaTime/timeTaken;
                    }
                }else{
                    increasing = !increasing;
                    currentLoop += 1;
                    if (currentLoop == loops){
                        freeze = freezeTime; 
                        currentLoop = 0;
                        GameObject spawnerToActivate;
                        if (lerpTime >= 1f){
                            spawnerToActivate = Point2.gameObject;
                        }else{
                            spawnerToActivate = Point1.gameObject;
                        }
                        spawnerToActivate.GetComponent<SpawnPrefab>().isSpawning = true;
                        //spawnerToActivate.isSpawning = true;
                    }
                }
            }else{
                freeze -= Time.deltaTime;
                if (freeze <= 0f){
                    freeze = 0f;
                    SpawnPrefab spawnerToDeactivate;
                    if (lerpTime >= 1f){
                        spawnerToDeactivate = Point2.gameObject.GetComponent<SpawnPrefab>();
                    }else{
                        spawnerToDeactivate = Point1.gameObject.GetComponent<SpawnPrefab>();
                    }
                    spawnerToDeactivate.isSpawning = false;
                }
            }
        }else{
            currentHurtTime -= Time.deltaTime;
        }
        transform.position = Vector2.Lerp(Point1.position, Point2.position, lerpTime);
    }
}
