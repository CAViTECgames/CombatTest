using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combat : MonoBehaviour {

    public GameObject Wolf;
    public GameObject Wolf2;
    public GameObject Wolf3;
    public GameObject Bandit;
    public GameObject Character;
    public GameObject Caravan;
    public GameObject Texto;
    public GameObject Negotiator_Bandit;
    public Text Damage;
    private Transform TargetWolf;
    private Transform TargetBandit;
    private Transform TargetNegotiator_Bandit;
    private GameObject[] WolfArray;
    private bool hit;
    private int combatcount;

    private void Start()
    {
        //inicializaciones
        WolfArray = GameObject.FindGameObjectsWithTag("Wolf");

        for (int i = 0; i < WolfArray.Length; i++)
            WolfArray[i].gameObject.SetActive(false);

        Texto.gameObject.SetActive(false);
        Bandit.gameObject.SetActive(false);
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

    public void BanditCombatzone()
    {

        Bandit.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = !Bandit.gameObject.GetComponent<GoAndNavigate>().myNav.enabled;
        Bandit.gameObject.GetComponent<GoAndNavigate>().enabled = !Bandit.gameObject.GetComponent<GoAndNavigate>().enabled;

        hit = !hit;
        CombatBandit();
    }

    public void WolfCombatzone()
    {
        /*
        for (int i = 0; i < WolfArray.Length; i++)
        {
            //si acaba de entrar o salir de la zona debe anularse o reactivarse el navegador respectivamente
            WolfArray[i].gameObject.GetComponent<GoAndNavigate>().myNav.enabled = !WolfArray[i].gameObject.GetComponent<GoAndNavigate>().myNav.enabled;
            WolfArray[i].gameObject.GetComponent<GoAndNavigate>().enabled = !WolfArray[i].gameObject.GetComponent<GoAndNavigate>().enabled;
            WolfArray[i].gameObject.GetComponent<Characteristic_Wolf>().hit = !WolfArray[i].gameObject.GetComponent<Characteristic_Wolf>().hit;
        }
        */
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

    public void CombatBandit()
    {
        //si ha pasado el tiempo suficiente y esta en la zona de combate hace daño
        if (Bandit.gameObject.GetComponent<Characteristic_Bandit>().getCombatCount() > 300 && hit == true)
        {
            // muestra el texto de daño
            Damage.enabled = true;
            TargetBandit = Bandit.gameObject.GetComponent<GoAndNavigate>().Target;

            // si su target es la caravana pega a la caravana
            if (TargetBandit.gameObject.CompareTag("Caravana"))
            {
                Caravan.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
                Caravan.gameObject.GetComponent<GoAndNavigate>().enabled = false;
                Debug.LogError("DAMAGE!!");
                TargetBandit.gameObject.GetComponent<Characteristic_Caravan>().Set_life(
                    Bandit.gameObject.GetComponent<Characteristic_Bandit>().Do_damage("Caravan"));

            }
            else
            {
                Caravan.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
                Caravan.gameObject.GetComponent<GoAndNavigate>().enabled = false;
                TargetBandit.gameObject.GetComponent<Characteristic_Character>().Set_life(
                    Bandit.gameObject.GetComponent<Characteristic_Bandit>().Do_damage("Character"));
                Debug.LogWarning("DAMAGE!!");
            }
            Bandit.gameObject.GetComponent<Characteristic_Bandit>().setCombatCount(0);
        }
    }

    public void CombatNegotiatorBandit()
    {
        //si ha pasado el tiempo suficiente y esta en la zona de combate hace daño
        if (Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().getCombatCount() > 500 && hit == true)
        {
            // muestra el texto de daño
            Damage.enabled = true;
            TargetNegotiator_Bandit = Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>().Target;

            // si su target es la caravana pega a la caravana
            if (TargetNegotiator_Bandit.gameObject.CompareTag("Caravana"))
            {
                Caravan.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
                Caravan.gameObject.GetComponent<GoAndNavigate>().enabled = false;
                Debug.LogWarning("Caravana Negotiator Bandit DAMAGE!!");
                TargetNegotiator_Bandit.gameObject.GetComponent<Characteristic_Caravan>().Set_life(
                    Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().Do_damage("Caravan"));

            }
            else
            {
                TargetNegotiator_Bandit.gameObject.GetComponent<Characteristic_Character>().Set_life(
                    Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().Do_damage("Character"));
                Debug.LogWarning("Player Negotiator Bandit DAMAGE!!");
            }
            Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().setCombatCount(0);
        }
    }

    public void CombatWolf()
    {
        for (int i = 0; i < WolfArray.Length; i++)
        {
            //si ha pasado el tiempo suficiente y esta en la zona de combate hace daño
            if (WolfArray[i].gameObject.GetComponent<Characteristic_Wolf>().getCombatCount() > 300 && hit == true)
            {
                // muestra el texto de daño
                Damage.enabled = true;
                TargetWolf = WolfArray[i].gameObject.GetComponent<GoAndNavigate>().Target;

                // si su target es la caravana pega a la caravana
                if (TargetWolf.gameObject.CompareTag("Caravana"))
                {
                    Caravan.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
                    Caravan.gameObject.GetComponent<GoAndNavigate>().enabled = false;
                    Debug.LogWarning("Caravana Wolf DAMAGE!!");
                    TargetWolf.gameObject.GetComponent<Characteristic_Caravan>().Set_life(
                        WolfArray[i].gameObject.GetComponent<Characteristic_Wolf>().Do_damage("Caravan"));

                }
                else
                {
                    TargetWolf.gameObject.GetComponent<Characteristic_Character>().Set_life(
                        WolfArray[i].gameObject.GetComponent<Characteristic_Wolf>().Do_damage("Character"));
                    Debug.LogWarning("Player Wolf DAMAGE!!");
                }
                WolfArray[i].gameObject.GetComponent<Characteristic_Wolf>().setCombatCount(0);
            }
        }
    }

    public void CombatSword(GameObject target)
    {
        //si ha pasado el tiempo suficiente y esta en la zona de combate hace daño

        if (Character.gameObject.GetComponent<Characteristic_Bandit>().getCombatCount() > 250 && hit == true)
        {
            // muestra el texto de daño

            // si su target es la caravana pega a la caravana
            if (target.CompareTag("Wolf"))
            {
                target.GetComponent<Characteristic_Wolf>().Set_life(Character.gameObject.GetComponent<Characteristic_Character>().Do_damage("Wolf"));
            }
            else if(target.CompareTag("Negotiator_Bandit"))
            {

            }
            else if(target.CompareTag("Bandit"))
            {
                target.GetComponent<Characteristic_Bandit>().Set_life(Character.gameObject.GetComponent<Characteristic_Character>().Do_damage("Bandit"));
            }
            combatcount = 0;
        }
    }
}
