using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCollisionTags : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject otherObject = collision.gameObject;

        string thisObjectName = gameObject.name;
        string otherObjectName = otherObject.name;

        string thisObjectTag = gameObject.tag;
        string otherObjectTag = otherObject.tag;

        string message = string.Format("Collision between {0} ({1}) and {2} ({3})",
            thisObjectName, thisObjectTag, otherObjectName, otherObjectTag);

        Debug.Log(message);
    }
}
