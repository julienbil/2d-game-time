using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int direction;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(0,0,90);
    }

    // Update is called once per frame
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Stats>().hp -= 10;
            other.GetComponent<Stats>().realHp -= 10;
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3 (direction * speed/100,0,0);
        StartCoroutine(SelfDestruct());
    }
}
