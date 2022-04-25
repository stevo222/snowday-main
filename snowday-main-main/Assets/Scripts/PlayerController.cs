using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 20.0f;
    private Rigidbody playerRb;
    private float zBound = 7;
    public GameObject projectilePrefab;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _canFire = -1f;
    [SerializeField] private int _lives = 4;
    [SerializeField] private Animator playerAnim;
    public UnityEvent fireEvent;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayer();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            fireEvent.Invoke();
            _canFire = Time.time + _fireRate;
            Instantiate(projectilePrefab, transform.position + new Vector3(0.12f, 0, 0), Quaternion.identity);
        }

    }

    // moves the player 
    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.forward * speed * verticalInput);
        playerRb.AddForce(Vector3.right * speed * horizontalInput);
    }

    //boundraies
    void ConstrainPlayer()
    {
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }

        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
        if (collision.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Player has collided with fire");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Damage();
        }
        if (other.gameObject.CompareTag("Snowflake"))
        {
            Destroy(other.gameObject);
        }
    }

    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
