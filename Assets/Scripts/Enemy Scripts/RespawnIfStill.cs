using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnIfStill : MonoBehaviour{
    public GameObject check;
    private Vector3 originalPos;
    // Start is called before the first frame update
    void Start()
    {
        originalPos = new Vector3(transform.position.x,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDestroy(){
        if((gameObject.scene.isLoaded)&&(check != null)){
            GameObject created = Instantiate(gameObject, originalPos, Quaternion.identity);
            created.SetActive(true);
            BoxCollider2D bc = created.GetComponent<BoxCollider2D>();
            bc.enabled = true;
            ChasePlayer cp = created.GetComponent<ChasePlayer>();
            cp.enabled = true;
            DetectStomp ds = created.GetComponent<DetectStomp>();
            ds.enabled = true;
            JumpOnStomp jos = created.GetComponent<JumpOnStomp>();
            jos.enabled = true;
            DetectKick dc = created.GetComponent<DetectKick>();
            dc.enabled = true;
            FlyOnKick fok = created.GetComponent<FlyOnKick>();
            fok.enabled = true;
            RespawnIfStill ris = created.GetComponent<RespawnIfStill>();
            ris.enabled = true;
            ChangeAim ca = created.GetComponentInChildren<ChangeAim>(true);
            ca.enabled = true;
        }
    }
}
