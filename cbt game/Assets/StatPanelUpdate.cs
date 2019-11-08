using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatPanelUpdate : MonoBehaviour
{
    public TextMeshProUGUI life, strength, intelligence, endurance, agilty;
    public Stats stats;

    private void Start()
    {
        PanelUpdate();
    }

    public void PanelUpdate()
    {
        life.text = "Health " + stats.life;

        strength.text = "Strength " + stats.strength;

        intelligence.text = "Intelligence " + stats.intelligence;

        endurance.text = "Endurance " + stats.endurance;

        agilty.text = "Agility " + stats.agility;
    }
}
