using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerThings : MonoBehaviour
{
    public Stats stats;
    public Transform hpT, manaT, xpT;
    public TextMeshProUGUI hpText, manaText, xpText, lvlText, skillText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpT.localScale = new Vector3((float)stats.hp/(float)stats.maxHp,1,1);
        hpText.text = stats.hp + "/" + stats.maxHp;

        manaT.localScale = new Vector3((float)stats.mana / (float)stats.maxMana, 1, 1);
        manaText.text = stats.mana + "/" + stats.maxMana;

        xpT.localScale = new Vector3((float)stats.xp / (float)stats.maxXp, 1, 1);
        xpText.text = stats.xp + "/" + stats.maxXp;

        lvlText.text = stats.lvl.ToString();

        skillText.text = "Skill Points: \n"+stats.skillPts;
    }
}
