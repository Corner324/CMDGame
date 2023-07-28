using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyLogic : MonoBehaviour
{
    public int health = 3;
    public AudioClip soundClipDeath;
    private AudioSource audioSource;
    public TextMeshPro score;


    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = health.ToString();
        print(gameObject.name + " / " + health);
        if (health <= 0){
            audioSource.PlayOneShot(soundClipDeath);
            Destroy(gameObject);
        }
    }
}
