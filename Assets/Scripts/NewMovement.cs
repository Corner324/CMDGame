using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{

    public float Speed = 2f;
    private Rigidbody2D _rb;
    public Transform  point;

    private Vector2 target; 
    private Vector2 player; 

    private Vector2 vec;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        MovementLogic(); 
    }


    private void MovementLogic()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        float moveVertical = Input.GetAxis("Vertical");
        print(moveVertical);

        target = point.position;
        player = transform.position;

        vec = target - player;

        _rb.AddForce((Vector2)vec * Speed);
    }

}
