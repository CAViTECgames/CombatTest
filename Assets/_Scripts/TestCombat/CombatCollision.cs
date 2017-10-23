﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCollision : MonoBehaviour {

    public Transform Wolf;
    public Transform Caravana;
    public Transform Player;
    private GoAndNavigate Nav;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Personaje") || other.gameObject.CompareTag("Caravana"))
        {
            Wolf.gameObject.SetActive(true);
            float distC = Vector3.Distance(Caravana.position, Wolf.position);
            Debug.LogWarning("DistC: " + distC);
            float distP = Vector3.Distance(Player.position, Wolf.position);
            Debug.LogWarning("DistP: " + distP);
            if (distC >= distP)
            {
                Nav = Wolf.gameObject.GetComponent<GoAndNavigate>();
                Nav.Target = Player;
            }
            else
            {
                Nav = Wolf.gameObject.GetComponent<GoAndNavigate>();
                Nav.Target = Caravana;
            }
            this.gameObject.SetActive(false);
        }
    }
}
