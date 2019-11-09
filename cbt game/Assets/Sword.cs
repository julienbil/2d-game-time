using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Attack attackType;
    public Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        attackType = Attack.Null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (attackType != Attack.Null && other.gameObject.tag == "Enemy")
        {
            if (attackType == Attack.J)
                other.gameObject.GetComponent<Retard>().TakeDamage(stats.strength,1f);
            else if (attackType == Attack.K)
                other.gameObject.GetComponent<Retard>().TakeDamage(stats.strength, 1.5f);
            else if (attackType == Attack.L)
                other.gameObject.GetComponent<Retard>().TakeDamage(stats.strength, 2.5f);
        }
    }
}

public enum Attack
{
    J,K,L,Null
}