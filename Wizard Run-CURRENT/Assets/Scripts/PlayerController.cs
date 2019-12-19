using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 10.0f;
    public GameObject projectilePrefab;
    public float fireDelta = 1.0f;
    private float nextFire = 0.0f;
    private float verticalInput;
    public Rigidbody playerRb;
    private float posBound = 24.0f;
    private float negBound = -24.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            //When space is pressed down run code and Fire Fireballs!
            nextFire = Time.time + fireDelta;
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
        var player = GameObject.Find("Player");
        if (transform.position.x > posBound)
        {
            //transform.position.x = posBound;
            //transform.Translate(posBound, transform.position.y, transform.position.z);
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        else if (transform.position.x < negBound)
        {
            //transform.position.x = negBound;
            //transform.Translate(negBound, transform.position.y, transform.position.z);
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
        }
        if (player.transform.position.z > posBound)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        else if (player.transform.position.z < negBound)
        {
            Destroy(gameObject);
            Debug.Log("Game Over");
        }
        else
        {
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Debug.Log("Game Over");
        }        
    } 
        
    
}
