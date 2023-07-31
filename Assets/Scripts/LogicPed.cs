using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicPed: MonoBehaviour
{


    private TextMeshPro score;
    private LoadInCar loadInCar;

    GameObject resGameObject;
    

    // Запуск игры
    void Awake(){

    }


    // Start is called before the first frame update
    void Start()
    {   
        if(transform.childCount > 0){
            score = transform.GetChild(0).GetComponent<TextMeshPro>();
            score.text = "0";
        }

    }


    // Update is called once per frame
    void Update()
    {   
        if(gameObject.tag != "Car" && gameObject.tag != "Tank"){ // Fixed it!!
            GameObject car = nearestCar(transform.position);
            if(Vector3.Distance(transform.position, car.transform.position) <= 0.3f){
                print("Рядом пехота!");
                LoadCar(car);
            }
        }
    }

    private void LoadCar(GameObject car){
        loadInCar = car.GetComponent<LoadInCar>();
        if(loadInCar.countPassengers < loadInCar.maxCount){
            Destroy(gameObject); // Set time for loading
            loadInCar.countPassengers += 1;
            print("Загружается в машину!");
            // добавить звук загрузки
        }
    }

    GameObject nearestCar(Vector2 actualPosition){
        float minDistance = 10000.0f; // Md-ma...
        GameObject[] cars = GameObject.FindGameObjectsWithTag("Car");

        foreach (GameObject car in cars)
        {
            if(Vector2.Distance(actualPosition, car.transform.position) < minDistance){
                resGameObject = car;
                minDistance = Vector2.Distance(actualPosition, car.transform.position);
            }

            return resGameObject;
        }

        return null; 
    }

}


