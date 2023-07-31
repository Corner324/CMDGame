using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ZoomCamera : MonoBehaviour
{   

    Vector3 touch; 
    Vector3 direction;


    public float minZoom = 2f;
    public float maxZoom = 8f;
    public float sensivity = 3f;

    void Start(){
       
    }


    void Update()
    {   

        if(Input.GetMouseButtonDown(1)) { 
            touch = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        } 

        if (Input.GetMouseButton(1)) { 
            movementCamera();
        } 

        if (Convert.ToBoolean(Input.GetAxis("Mouse ScrollWheel")))
        {
            zoomCamera(Input.GetAxis("Mouse ScrollWheel"));
        }
    }

    void zoomCamera(float increment)
    {
        GetComponent<Camera>().orthographicSize = Mathf.Clamp(GetComponent<Camera>().orthographicSize - increment * sensivity, minZoom, maxZoom);
    }


    void movementCamera()
    {
        direction = touch - Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        Camera.main.transform.position += direction; 
    }
}
