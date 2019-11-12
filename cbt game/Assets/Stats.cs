using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int life, strength, intelligence, endurance, agility,
        hp, maxHp, mana, maxMana, lvl, xp, maxXp, skillPts;
    public float manaRegen, realMana, realHp;
    public GameObject modelHolder,deathPanel;
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
        realHp = maxHp;
        hp = (int)realHp;
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
            TakeDamage(collision.gameObject.GetComponent<Retard>().power, collision.gameObject.GetComponent<Retard>().lvl);
        }
    }

    public void TakeDamage(int damage, int lvlE)
    {
        if(lvlE - lvl >= -5)
        {
            realHp -= damage*(1-endurance/100f)*(1+(lvlE-lvl)/5f);
            if (realHp <= 0)
                Death();
            hp = (int)realHp;
        }
        StartCoroutine(Invincible());
        IEnumerator Invincible()
        {
            Physics.IgnoreLayerCollision(8, 9, true);
            modelHolder.SetActive(false);
            yield return new WaitForSeconds(0.15f);
            modelHolder.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            modelHolder.SetActive(false);
            yield return new WaitForSeconds(0.15f);
            modelHolder.SetActive(true);
            yield return new WaitForSeconds(0.15f);
            modelHolder.SetActive(false);
            yield return new WaitForSeconds(0.15f);
            modelHolder.SetActive(true);
            Physics.IgnoreLayerCollision(8, 9, false);
        }
    }

    void Death()
    {
        realHp = 0;
        hp = (int)realHp;
        deathPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        realHp = maxHp;
        hp = (int)realHp;
        realMana = maxMana;
        mana = (int)realMana;
        modelHolder.SetActive(true);
        transform.position = new Vector3(0, 3, 0);
        gameObject.SetActive(true);
    }
}