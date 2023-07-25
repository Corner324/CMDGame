using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FobCreation : MonoBehaviour
{

    private TextMeshPro tiemer;
    private bool placed = false;
    private bool available = false;
    public int seconds = 10;

    private float timerInterval = 1f; // Интервал времени в секундах
    private bool isTimerRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StartTimer()
    {
        if (!isTimerRunning)
        {
            // Вызываем функцию TimerTick каждую секунду, начиная с текущего момента
            InvokeRepeating("TimerTick", 0f, timerInterval);
            isTimerRunning = true;
        }
    }

    private void TimerTick()
    {
        if (placed && seconds >= 0 && !available){
            tiemer.text = Convert.ToString(seconds);
            seconds -= 1;
            if(seconds == 0){
                available = true;
                tiemer.text = "";
                SpriteRenderer spr = transform.GetComponent<SpriteRenderer>();
                spr.color = Color.green;


                return;
            }
        }
    }

    void OnEnable(){

        if(transform.childCount > 0){
            tiemer = transform.GetChild(1).GetComponent<TextMeshPro>();
            tiemer.text = Convert.ToString(seconds);
        }
        placed = true;

        StartTimer();

    }
}
