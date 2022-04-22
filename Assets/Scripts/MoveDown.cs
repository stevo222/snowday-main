using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -12.0f;
    private Rigidbody objectRB;
    public ParticleSystem fireParticle;
    private Animator fireAnim;

    // Start is called before the first frame update
    void Start()
    {

        objectRB = GetComponent<Rigidbody>();
        fireAnim = GetComponent<Animator>();
        fireParticle.Play();

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
}
