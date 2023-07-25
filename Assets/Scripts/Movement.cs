using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{

    private Transform pointerPos;
    private TextMeshPro score;

    public float maxMoveSpeed = 0.1f;
    public float smoothTime = 5f;
    [Space]
    
    public float maxTurnSpeedAngel=320;
    public float smoothTimeAngel = 0.01f;

    Vector2 currentVelocity;
    Vector2 mousePosition;
    float currentVelocityAngel;
    float angle;

    public bool isMoving;
    public bool lockPoint = false;

    [Space]
    UnityEngine.AI.NavMeshAgent agent;
    Vector2 startPos;
    Vector2 endPos;

    Vector3 currentDirection;

    public static Movement Instance {get; set;}

    Vector3 position;

    public GameObject objPoin;
    Vector2 randomPoint;

    public LineRenderer lineRenderer;

    // Запуск игры
    void Awake(){
        Instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {   
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        isMoving = false;
        pointerPos = GameObject.Find("Pointer").transform;

        if(transform.childCount > 0){
            score = transform.GetChild(0).GetComponent<TextMeshPro>();
            score.text = "0";
        }
        
        if(gameObject.CompareTag("Car")){
            agent.speed = 0.5f;
        }
        else if(gameObject.CompareTag("Tank")){
            agent.speed = 0.1f;
        }

        position = transform.position;
        
    }


    // Update is called once per frame
    void Update()
    {   
        if (Vector3.Distance(pointerPos.position, transform.position) > 1.0f){
            isMoving = true;
            score.text = "Go " + isMoving.ToString();
            agent.SetDestination(pointerPos.position);
        
            SmoothAngel();
            lockPoint = false;
        }
        else if (Vector3.Distance(pointerPos.position, transform.position) < 1.0f && isMoving) // Nearby
        {
            isMoving = false;
            print("Nearby");
            score.text = "Nearby " + isMoving.ToString();
            if (!lockPoint){
                randomPoint = GetCoordInCircle();
                lockPoint = true;
            }
            agent.SetDestination(randomPoint);
            SmoothAngel();
        }

        if (agent.hasPath)
        {
            DrawPath(agent.path);
        }
        

    }

    private void DrawPath(UnityEngine.AI.NavMeshPath path)
    {
        lineRenderer.positionCount = path.corners.Length;
        lineRenderer.SetPositions(path.corners);
    }


    Vector2 GetCoordInCircle(){
        Transform circle = pointerPos;
        float centerX = circle.position.x;
        float centerY = circle.position.y;
        float radius = 0.5f;

        float angle = UnityEngine.Random.Range(0f, 2f * Mathf.PI);
        Vector2 randomPoint = new Vector2(centerX + Mathf.Cos(angle) * radius, centerY + Mathf.Sin(angle) * radius);

        Vector3 posForPoin = new Vector3 (randomPoint[0], randomPoint[1], 0);
        Instantiate (objPoin, posForPoin, Quaternion.identity);

        return randomPoint;
    }

    void SmoothMovement(Vector2 position){
        transform.position = Vector2.SmoothDamp(transform.position, position, ref currentVelocity, smoothTime, maxMoveSpeed); 
    
    }
 

    void SmoothAngel(){
        Vector3 currentDirection = (transform.position-position).normalized;

        float targetAngle = Vector2.SignedAngle(Vector2.up, currentDirection);
        angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocityAngel, smoothTimeAngel, maxTurnSpeedAngel);
        transform.eulerAngles = new Vector3 (0, 0, angle);
        position = transform.position;
    }

}


