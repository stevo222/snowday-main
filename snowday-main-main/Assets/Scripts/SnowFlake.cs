using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowFlake : MonoBehaviour
{
    public float speed = 2.0f;
    private float yDestroy = -15.0f;
    private Rigidbody objectRB;
    // Start is called before the first frame update
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectRB.AddForce(Vector3.up * -speed);

        if (transform.position.y < yDestroy)
        {
            Destroy(gameObject);
        }
    }
}
