using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //public GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D collision) {
        //GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        //Destroy(effect, 5f);

        if (collision != null)
        {
            GameObject collidedObject = collision.gameObject;
            if (collidedObject.tag == "Bullet"){
                return;
            }
            EnemyLogic enemyLogic = collidedObject.GetComponent<EnemyLogic>();
            if (enemyLogic != null)
            {
                if(enemyLogic.health > 0){
                    enemyLogic.health -= 1; 
                }
            }
            Destroy(gameObject);
        }
        
    }

    private void Update(){
        Destroy(gameObject, 1f);
    }
    
    private void Start(){
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }
}
