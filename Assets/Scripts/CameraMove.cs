using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float speed;
    float screenWidth;
    float screenHeigth;

    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.width;
        screenHeigth = Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = transform.position;

        if(Input.mousePosition.x < 20){
            cameraPos.x -= speed * Time.deltaTime;
        }
        else if(Input.mousePosition.y < 20){
            cameraPos.y -= speed * Time.deltaTime;
        }
        else if(Input.mousePosition.y > screenWidth - 20){
            cameraPos.x += speed * Time.deltaTime;
        }
        else if(Input.mousePosition.y > screenHeigth - 20){
            cameraPos.y += speed * Time.deltaTime;
        }

        transform.position = new Vector3(Mathf.Clamp(cameraPos.x, 200, 634), Mathf.Clamp(cameraPos.y, 181, 403), cameraPos.z);
    }
}
