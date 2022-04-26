using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -12.0f;
    private Rigidbody objectRB;
    private GameManager gameManager;
    public int pointValue;
    public int ExtraLife;
    public GameObject explosionFx;
    private AudioSource enemyAudio;
    public AudioClip explosionAudio;

    // public PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {

        
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        objectRB = GetComponent<Rigidbody>();
        enemyAudio = GetComponent<AudioSource>();
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {

        
        objectRB.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
            

        }
    }

    private void OnTriggerEnter (Collider other)
    {
        Destroy(gameObject);
        Explode();
        gameManager.UpdateScore(pointValue);
        
        //Destroy(other.gameObject);


    }

    void Explode()
    {
        
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        enemyAudio.PlayOneShot(explosionAudio, 1.0f);

    }


}
