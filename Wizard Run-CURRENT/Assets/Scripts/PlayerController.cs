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
    private float speed = 10.0f;
    public Rigidbody playerRb;
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
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);

    }
    // {
    //     horizontalInput = Input.GetAxis("Horizontal");
    //     verticalInput = Input.GetAxis("Vertical");
    //     transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
    //     transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
    //    }

        
    
}
