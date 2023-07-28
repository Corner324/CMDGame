using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LogicPed: MonoBehaviour
{


    private TextMeshPro score;

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

    }


}


