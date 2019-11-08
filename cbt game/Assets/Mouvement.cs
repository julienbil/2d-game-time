using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    public bool grounded;
    public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        grounded = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space)&&grounded)
        {
            rb.velocity += new Vector3(0, 10, 0);
            grounded = false;
        }
        if (Input.GetKey(KeyCode.A)&& rb.velocity.x >= -maxVelocity)
        {
            rb.velocity += new Vector3(-1, 0, 0);
        }
        /*if(Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector3(0, -1, 0);
        }*/
        if(Input.GetKey(KeyCode.D)&& rb.velocity.x <= maxVelocity)
        {
            rb.velocity += new Vector3(1, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
