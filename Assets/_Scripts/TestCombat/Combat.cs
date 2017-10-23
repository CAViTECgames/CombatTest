using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour {

    public GameObject Wolf;
    public GameObject Character;
    public GameObject Caravan;
    public GameObject Texto;
    public GameObject Negotiator_Bandit;
    public Text Damage;
    private Transform TargetWolf;
    private Transform TargetBandit;
    private bool hit;
    private int combatcount;

    private void Start()
    {
        //inicializaciones 
        Texto.gameObject.SetActive(false);
        Wolf.gameObject.SetActive(false);
        combatcount = 0;
        hit = false;
        Damage.enabled = false;
    }

     void FixedUpdate()
    {
        //contador del tiempo de combate 
        Wolf.gameObject.GetComponent<Characteristic_Wolf>().autoRaiseCombatCount(1);
        Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().autoRaiseCombatCount(1);

        //Debug.LogWarning("Combat time: " + Wolf.gameObject.GetComponent<Characteristic_Wolf>().getCombatCount());
        if (Wolf.gameObject.GetComponent<Characteristic_Wolf>().getCombatCount() == 100)
        {
            Damage.enabled = false;
        }
       
    }

    public void WolfCombatzone()
    {
        //si acaba de entrar o salir de la zona debe anularse o reactivarse el navegador respectivamente
        Wolf.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = !Wolf.gameObject.GetComponent<GoAndNavigate>().myNav.enabled;
        Wolf.gameObject.GetComponent<GoAndNavigate>().enabled = !Wolf.gameObject.GetComponent<GoAndNavigate>().enabled;
        
        hit = !hit;
        CombatWolf();
    }

    public void NegotiatorBanditCombatzone()
    {
        //si acaba de entrar o salir de la zona debe anularse o reactivarse el navegador respectivamente
        Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = !Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>().myNav.enabled;
        Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>().enabled = !Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>().enabled;

        hit = !hit;
        CombatNegotiatorBandit();
    }

    public void CombatNegotiatorBandit()
    {
        //si ha pasado el tiempo suficiente y esta en la zona de combate hace daño
        if (Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().getCombatCount() > 500 && hit == true)
        {
            // muestra el texto de daño
            Damage.enabled = true;
            TargetBandit = Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>().Target;

            // si su target es la caravana pega a la caravana
            if (TargetBandit.gameObject.CompareTag("Caravana"))
            {
                Caravan.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
                Caravan.gameObject.GetComponent<GoAndNavigate>().enabled = false;
                Debug.LogWarning("Caravana Negotiator Bandit DAMAGE!!");
                TargetBandit.gameObject.GetComponent<Characteristic_Caravan>().Set_life(
                    Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().Do_damage("Caravan"));

            }
            else
            {
                TargetBandit.gameObject.GetComponent<Characteristic_Character>().Set_life(
                    Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().Do_damage("Character"));
                Debug.LogWarning("Player Negotiator Bandit DAMAGE!!");
            }
            Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().setCombatCount(0);
        }
    }

    public void CombatWolf()
    {
        //si ha pasado el tiempo suficiente y esta en la zona de combate hace daño
        if (Wolf.gameObject.GetComponent<Characteristic_Wolf>().getCombatCount() > 300 && hit == true)
        {
            // muestra el texto de daño
            Damage.enabled = true;
            TargetWolf = Wolf.gameObject.GetComponent<GoAndNavigate>().Target;

           // si su target es la caravana pega a la caravana
            if (TargetWolf.gameObject.CompareTag("Caravana"))
            {
                Caravan.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
                Caravan.gameObject.GetComponent<GoAndNavigate>().enabled = false;
                Debug.LogWarning("Caravana Wolf DAMAGE!!");
                TargetWolf.gameObject.GetComponent<Characteristic_Caravan>().Set_life(
                    Wolf.gameObject.GetComponent<Characteristic_Wolf>().Do_damage("Caravan"));

            }
            else
            {
                TargetWolf.gameObject.GetComponent<Characteristic_Character>().Set_life(
                    Wolf.gameObject.GetComponent<Characteristic_Wolf>().Do_damage("Character"));
                Debug.LogWarning("Player Wolf DAMAGE!!");
            }
            Wolf.gameObject.GetComponent<Characteristic_Wolf>().setCombatCount(0);
        }
    }
}
