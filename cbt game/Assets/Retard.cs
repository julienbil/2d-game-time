using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retard : MonoBehaviour
{
    public float maxVelocity;
    Rigidbody rb;
    Transform pTransform;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        pTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < pTransform.position.x)
            GoRight();
        else if (transform.position.x > pTransform.position.x)
            GoLeft();
    }

    void GoRight()
    {
        if(rb.velocity.x <= maxVelocity)
            rb.velocity += new Vector3(1, 0, 0);
    }

    void GoLeft()
    {
        if (rb.velocity.x >= -maxVelocity)
            rb.velocity += new Vector3(-1, 0, 0);
    }
}
