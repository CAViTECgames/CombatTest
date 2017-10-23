using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collision : MonoBehaviour {

    public UIController Dialogo;

    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.CompareTag("Pista"))
        {
            other.gameObject.SetActive(false);
            Dialogo.Pista();
        }
    }
}
