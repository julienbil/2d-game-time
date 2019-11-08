using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int life, strength, intelligence, endurance, agility,
        hp, maxHp, mana, maxMana, lvl, xp, maxXp, skillPts;
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
        mana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        if (xp >= maxXp)
        {
            lvl++;
            xp = 0;
            skillPts++;
            maxXp = lvl * 2;
        }
    }

    void addLife()
    {
        if (skillPts > 0)
        {
            life++;
            maxHp = life * 15;
            hp = maxHp;
            skillPts--;
        }
    }
    void addStrength()
    {
        if (skillPts > 0)
        {
            strength++;
            skillPts--;
        }
    }
    void addIntelligence()
    {
        if (skillPts > 0)
        {
            intelligence++;
            maxMana = intelligence * 10;
            mana = maxMana;
            skillPts--;
        }
    }
    void addEndurance()
    {
        if (skillPts > 0)
        {
            endurance++;
            skillPts--;
        }
    }
    void addAgility()
    {
        if (skillPts > 0)
        {
            agility++;
            skillPts--;
        }
    }
}
