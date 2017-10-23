using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnterCombat : MonoBehaviour {
    public Combat Combat;
    public Transform Unit;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Personaje") || other.gameObject.CompareTag("Caravana"))
        {
            Debug.LogError("Entrando en zona combate");
            if (Unit.gameObject.CompareTag("Wolf"))
                Combat.WolfCombatzone();
            if (Unit.gameObject.CompareTag("Negotiator_Bandit"))
                Combat.NegotiatorBanditCombatzone();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Personaje") || other.gameObject.CompareTag("Caravana"))
        {
            if (Unit.gameObject.CompareTag("Wolf"))
                Combat.CombatWolf();
            if (Unit.gameObject.CompareTag("Negotiator_Bandit"))
                Combat.CombatNegotiatorBandit();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Personaje") || other.gameObject.CompareTag("Caravana"))
        {
            Debug.LogError("Saliendo de zona combate");
            if (Unit.gameObject.CompareTag("Wolf"))
                Combat.WolfCombatzone();
            if (Unit.gameObject.CompareTag("Negotiator_Bandit"))
                Combat.NegotiatorBanditCombatzone();
        }
    }
}
