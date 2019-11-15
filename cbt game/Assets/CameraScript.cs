using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float offsetX, offsetY;
    public Transform playerT;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector3(playerT.position.x+offsetX, playerT.position.y+offsetY, transform.position.z);
    }
}
