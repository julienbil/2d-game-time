using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retard : MonoBehaviour
{
    public float maxVelocity;
    Rigidbody rb;
    protected Transform pTransform;
    public Transform hpBar;
    public int power;
    Mouvement playerMV;
    Stats playerStats;
    public float realHp;
    public int hp,maxHp,lvl;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        pTransform = GameObject.FindWithTag("Player").transform;
        playerMV = GameObject.FindWithTag("Player").GetComponent<Mouvement>();
        playerStats = GameObject.FindWithTag("Player").GetComponent<Stats>();
        realHp = maxHp;
        hp = maxHp;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.x < pTransform.position.x)
            GoRight();
        else if (transform.position.x > pTransform.position.x)
            GoLeft();

        if (Input.GetKey(KeyCode.T))
        {
            TakeDamage(1, 1, 1);
        }

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

    public void TakeDamage(int strength, float ratio, int lvlP)
    {
        if (lvl - lvlP <= 5)
        {
            realHp -= strength * ratio * (1 - (lvl - lvlP) / 5f);
            if (realHp <= 0)
                Death();
            hp = (int)realHp;
            hpBar.localScale = new Vector3(1.5f*((float)hp/(float)maxHp),0.15f,0.00000001f);
        }
        
    }

    void Death()
    {
        playerStats.xp+=2;
        Destroy(gameObject);
    }
}
