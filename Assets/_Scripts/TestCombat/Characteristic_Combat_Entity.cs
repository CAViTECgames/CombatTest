using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic_Combat_Entity : MonoBehaviour
{
    protected int life, damage_caravan, damage_character; // Daño de los enemigos
    protected int damage_wolf, damage_bandit, damage_negotiator_bandit; // Daño del avatar
    protected int combatcount;  // Contador de tiempo de combate para cada unidad

    public int getLife()
    {
        return life;
    }

    public int getCombatCount()
    {
        return combatcount;
    }

    public void setCombatCount(int combatcount)
    {
        this.combatcount = combatcount;
    }

    public void autoRaiseCombatCount(int amount)
    {
        combatcount = combatcount + amount;
    }

    void Start()
    {
    }

    public void Set_life(int damage)
    //Resta a la vida la entrada damage
    {
        life = life - damage;
        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public int Do_damage(string target)
    {
        switch(target)
        {
            case "Caravan":
                return damage_caravan;
            case "Character":
                return damage_character;
            case "Wolf":
                return damage_wolf;
            case "Bandit":
                return damage_bandit;
            case "Negotiator_Bandit":
                return damage_negotiator_bandit;
            default:
                return 0;
        }
    }
}
