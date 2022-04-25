using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -12.0f;
    private Rigidbody objectRB;
    private GameManager gameManager;
    public int pointValue;
    public int ExtraLife;
   // public PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {

        objectRB = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();


    }

    // Update is called once per frame
    void Update()
    {

        
        objectRB.AddForce(Vector3.forward * -speed);

        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
        }
       // else
       // {
          //  playerControllerScript.lives += 1;
      //  }
    }

    private void OnTriggerEnter (Collider other)
    {
        //Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
