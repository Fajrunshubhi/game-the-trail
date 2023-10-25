using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityCameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
     public Transform highWall;
     public Transform lowWall;
     public Transform rightWall;
     public Transform leftWall;
 
     private float yMax;
     private float yMin;
     private float xMax;
     private float xMin;
    // Update is called once per frame
    void Update()
    {
        yMax = highWall.transform.position.y;
        yMin = 2.3f;
        xMax = rightWall.transform.position.x;
        xMin = -10.2f;

        //if within the bounds, camera locks onto player
        if(player.transform.position.y < yMax && player.transform.position.y > yMin){
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -110.0f);
        }

        //if player is above/below the y axis binders, camera locks to player on xAxis and stays stationary 
        //on yAxis
        if(player.transform.position.y > yMax){
            transform.position = new Vector3(player.transform.position.x, yMax, -110.0f);
        }else if(player.transform.position.y < yMin){
            transform.position = new Vector3(player.transform.position.x, yMin, -110.0f);
        }

        //if player is right/left of the xAxis binders, camera locks to player on yAxis and stays stationary 
        //on xAxis
        if(player.transform.position.x > xMax){
            transform.position = new Vector3(xMax, player.transform.position.y, -110.0f);
        }else if(player.transform.position.x < xMin){
            transform.position = new Vector3(xMin, player.transform.position.y, -110.0f);
        }

        //if player is above the yAxis binder, and to the right of the xAxis, the camera stays stationary
        if(player.transform.position.y > yMax && player.transform.position.x > xMax){
            transform.position = new Vector3(xMax, yMax, -110.0f);
        }
        //if player is above the yAxis binder, and to the left of the xAxis, the camera stays stationary
        if(player.transform.position.y > yMax && player.transform.position.x < xMin){
            transform.position = new Vector3(xMin, yMax, -110.0f);
        }
        //if player is below the yAxis binder, and to the right of the xAxis, the camera stays stationary
        if(player.transform.position.y < yMin && player.transform.position.x > xMax){
            transform.position = new Vector3(xMax, yMin, -110.0f);
        }
        //if player is below the yAxis binder, and to the left of the xAxis, the camera stays stationary
        if(player.transform.position.y < yMin && player.transform.position.x < xMin){
            transform.position = new Vector3(xMin, yMin, -110.0f);
        }
 

        // transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z );
        
    }
}
