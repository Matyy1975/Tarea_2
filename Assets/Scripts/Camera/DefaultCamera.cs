using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCamera : MonoBehaviour
{
    public Transform player;
    public float horizontalSmoothSpeed = 0.125f;
    public float verticalSmoothSpeed = 0.125f;
    public bool freezeHorizontal = false;
    public bool freezeVertical = false;

    private Vector2 desiredPosition;
    private Vector2 smoothedPosition;

    private void LateUpdate()
    {
        // Calculate the desired position with offset
        desiredPosition = (Vector2)player.position;

        // Smoothly transition to the desired position
        if (!freezeHorizontal) {
            smoothedPosition.x = Mathf.Lerp(transform.position.x, desiredPosition.x, horizontalSmoothSpeed);
        }else{ 
            smoothedPosition.x = transform.position.x;
        }
        if (!freezeVertical){
            smoothedPosition.y = Mathf.Lerp(transform.position.y, desiredPosition.y, verticalSmoothSpeed);
        }else{
            smoothedPosition.y = transform.position.y;
        }


        // Set the camera position
        transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
    }
}
