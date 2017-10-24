using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Characteristic_Character : Characteristic_Combat_Entity
{
    public Text lifetext;

    void Start()
    {
        life = 100;
        damage_wolf = 35;
        damage_bandit = 25;
        damage_negotiator_bandit = 20;
        unitName = "Character";
    }

}
