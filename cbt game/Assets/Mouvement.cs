using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    public bool grounded;
    public float maxVelocity;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = this.gameObject;
        rb = this.gameObject.GetComponent<Rigidbody>();
        grounded = true;
        anim = this.gameObject.GetComponent<Animator>();
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
            player.transform.eulerAngles = new Vector3(0, 90, 0);
            anim.SetBool("walking", true);
            rb.velocity += new Vector3(-1, 0, 0);
        }
        /*if(Input.GetKey(KeyCode.S))
        {
            rb.velocity += new Vector3(0, -1, 0);
        }*/
        if(Input.GetKey(KeyCode.D)&& rb.velocity.x <= maxVelocity)
        {
            player.transform.eulerAngles = new Vector3(0, -90, 0);
            anim.SetBool("walking", true);
            rb.velocity += new Vector3(1, 0, 0);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("walking", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
