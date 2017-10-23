using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegotiationCollision : MonoBehaviour {

    public Transform Negotiator_Bandit;
    public Transform Caravana;
    public Transform Player;
    public Transform Texto;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Personaje"))
        {
            Texto.gameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Caravana"))
        {
            Caravana.gameObject.GetComponent<GoAndNavigate>().myNav.enabled = false;
            Caravana.gameObject.GetComponent<GoAndNavigate>().enabled = false;
        }
        Debug.LogWarning("Se ha entrado en la zona");
    }

    public void StartAttack()
    {
        Texto.gameObject.SetActive(false);
        this.gameObject.SetActive(false);

        GoAndNavigate Nav = Negotiator_Bandit.gameObject.GetComponent<GoAndNavigate>();
        Nav.Target = Player;
    }

    public void Negotiate()
    {
        Texto.gameObject.SetActive(false);
        this.gameObject.SetActive(false);

        Caravana.gameObject.GetComponent<Characteristic_Character>().Set_life(
            Negotiator_Bandit.gameObject.GetComponent<Characteristic_Negotiator_Bandit>().Do_damage("Caravana") * 3);

        Negotiator_Bandit.gameObject.SetActive(false);
        // Reiniciar viaje de la caravana
    }
}
