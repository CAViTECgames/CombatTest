using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic_Bandit : Characteristic_Combat_Entity
{
    // Use this for initialization
    void Start()
    {
        unitName = "Bandit";
        life = 100;
        damage_caravan = 15;
        damage_character = 20;
    }

}
