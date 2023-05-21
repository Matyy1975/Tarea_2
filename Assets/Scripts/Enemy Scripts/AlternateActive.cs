using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To alternate between activating 2 GameObjects
public class AlternateActive : MonoBehaviour{
    public GameObject object1;
    public GameObject object2;
    public float switchTime = 1f;
    private float timeLeft;
    private bool active = true; //whether the active object is object1. object 2 is always at the opposite state.
    // Start is called before the first frame update
    void Start(){
        timeLeft = switchTime;
        object1.SetActive(true);
        object2.SetActive(false);
    }

    // Update is called once per frame
    void Update(){
        //Deal with the timer
        timeLeft = timeLeft - Time.deltaTime;
        if (timeLeft <= 0){
            timeLeft = switchTime;
            //switch the active objects
            active = !active;
            object1.SetActive(active);
            object2.SetActive(!active);
        }
    }
}
