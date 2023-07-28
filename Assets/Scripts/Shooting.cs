using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform firePoint;
    GameObject resGameObject;
    Vector3 direction;

    public AudioClip soundClipBullet;
    public AudioClip soundClipMissile;
    private AudioSource audioSource;

    public float bulletForce = 2f;

    public float maxDistance = 100f;

    private float shootingDelay = 0.7f; // Задержка между выстрелами в секундах
    private float shootingTimer = 0f; // Таймер для отслеживания времени

    GameObject bullet;

    GameObject[] enemies;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        shootingTimer += Time.deltaTime;

        if (shootingTimer >= shootingDelay)
        {
            shoot();

            shootingTimer = 0f;
        }
    }

    void shoot(){
        if(nearestEnemy()){
            GameObject enemy = nearestEnemy();
            direction = directionToEnemy(enemy);
        

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0f, 0f, angle);
            if (gameObject.tag == "Enemy" || gameObject.tag == "Inf"){
                bullet = Instantiate(bulletPrefab, firePoint.position, rotation);
                audioSource.PlayOneShot(soundClipBullet);
            } 
            else if(gameObject.tag == "Tank"){
                bullet = Instantiate(missilePrefab, firePoint.position, rotation);
                audioSource.PlayOneShot(soundClipMissile);
            }
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            Quaternion deviation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-3.4f, 3.4f));
            direction = deviation * direction;

            rb.velocity = direction * bulletForce;
            //rb.AddForce(direction * bulletForce, ForceMode2D.Impulse);
        }

    }
        
    GameObject nearestEnemy(){
        float minDistance = 10000.0f; // Md-ma...

        if(gameObject.tag == "Inf"){
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

        } else if (gameObject.tag == "Enemy"){
            enemies = GameObject.FindGameObjectsWithTag("Inf");
        }
        else if (gameObject.tag == "Tank"){
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        else{
            print(gameObject.tag);
        }

        if (enemies.Length == 0){
            return null;
        }
        foreach (GameObject enemy in enemies)
        {
            if(Vector2.Distance(firePoint.position, enemy.transform.position) < minDistance){
                resGameObject = enemy;
                minDistance = Vector2.Distance(firePoint.position, enemy.transform.position);
            }
        }

        if(Vector2.Distance(firePoint.position, resGameObject.transform.position) > maxDistance){
            return null;
        }

        return resGameObject;
    }

    Vector3 directionToEnemy(GameObject enemy){
        return enemy.transform.position - firePoint.position;

    }
}
