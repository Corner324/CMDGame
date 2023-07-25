using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerLogic : MonoBehaviour
{

    RaycastHit placeInfo;
    public MovePoint movePoint;

    public GameObject objCar;
    public GameObject objFob;
    public List<GameObject> units = new List<GameObject>();
    public List<GameObject> fabs = new List<GameObject>();

    GameObject resGameObject;


    void Start(){
        movePoint = FindObjectOfType<MovePoint>();
    }


    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out placeInfo))
            {
                if(placeInfo.collider.CompareTag("Ground"))
                {
                    movePoint.startPosition = placeInfo.point;
                }
            }
        }
        if (Input.GetKeyDown (KeyCode.G))
        {
            spawnUnit();
        }
        if (Input.GetKeyDown (KeyCode.F))
        {
            createFob();
        }

    }



    void spawnUnit(){
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        units.Add(Instantiate (objCar, worldPosition, Quaternion.identity) as GameObject);
    }

    void createFob(){

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (nearestCar(worldPosition)){
            GameObject car = nearestCar(worldPosition);
            if(Vector2.Distance(worldPosition, car.transform.position) > 1f){
                print("Слишком далеко!");
                print(Vector2.Distance(worldPosition, car.transform.position));
            }
            else{
                fabs.Add(Instantiate (objFob, worldPosition, Quaternion.identity) as GameObject);
            }
        }
    }

    GameObject nearestCar(Vector2 worldPosition){
        float minDistance = 10000.0f; // Md-ma...
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject car in cars)
        {
            if(Vector2.Distance(worldPosition, car.transform.position) < minDistance){
                resGameObject = car;
                minDistance = Vector2.Distance(worldPosition, car.transform.position);
            }

            return resGameObject;
        }

        return null; 
    }
}
