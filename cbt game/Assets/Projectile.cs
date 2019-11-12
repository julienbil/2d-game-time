using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int direction;
    public float speed;
    public int seconds, lvl, damage;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.eulerAngles = new Vector3(0,0,90);
    }

    // Update is called once per frame
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Stats>().TakeDamage(damage, lvl);
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        gameObject.transform.position += new Vector3 (direction * speed/100,0,0);
        StartCoroutine(SelfDestruct());
    }
}
