using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int life, strength, intelligence, endurance, agility,
        hp, maxHp, mana, maxMana, lvl, xp, maxXp, skillPts;
    public float manaRegen, realMana;
    // Start is called before the first frame update
    void Start()
    {
        lvl = 1;
        xp = 0;
        maxXp = lvl * 2;
        life = 5;
        strength = 5;
        intelligence = 5;
        endurance = 5;
        agility = 5;
        maxHp = life * 15;
        hp = maxHp;
        maxMana = intelligence * 10;
        realMana = maxMana;
    }

    // Update is called once per frame
    public void Update()
    {
        if (xp >= maxXp)
        {
            lvl++;
            xp = 0;
            skillPts++;
            maxXp = lvl * 2;
        }
        if (mana < maxMana)
        {
            realMana += (manaRegen * Time.deltaTime);
            mana = (int)realMana;
            if (realMana > maxMana)
            {
                realMana = maxMana;
                mana = maxMana;
            }
        }
    }

    public void addLife()
    {
        if (skillPts > 0)
        {
            life++;
            maxHp = life * 15;
            hp = maxHp;
            skillPts--;
        }
    }
    public void addStrength()
    {
        if (skillPts > 0)
        {
            strength++;
            skillPts--;
        }
    }
    public void addIntelligence()
    {
        if (skillPts > 0)
        {
            intelligence++;
            maxMana = intelligence * 10;
            realMana = maxMana;
            skillPts--;
        }
    }
    public void addEndurance()
    {
        if (skillPts > 0)
        {
            endurance++;
            skillPts--;
        }
    }
    public void addAgility()
    {
        if (skillPts > 0)
        {
            agility++;
            skillPts--;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(collision.gameObject.GetComponent<Retard>().power);
        }
    }

    void TakeDamage(int damage)
    {
        hp -= damage;
        if (hp < 0)
            hp = 0;
    }
}
