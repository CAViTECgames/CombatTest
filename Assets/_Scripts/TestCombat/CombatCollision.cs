using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCollision : MonoBehaviour {

    public Transform Wolf;
    public Transform Wolf2;
    public Transform Wolf3;
    public Transform Caravana;
    public Transform Player;
    private GoAndNavigate Nav;
    private GameObject[] WolfArray;

    void OnTriggerEnter(Collider other)
    {
        Wolf.gameObject.SetActive(true);
        Wolf2.gameObject.SetActive(true);
        Wolf3.gameObject.SetActive(true);

        WolfArray = GameObject.FindGameObjectsWithTag("Wolf");

        for (int i = 0; i < WolfArray.Length; i++)
        {

            if (other.gameObject.CompareTag("Personaje") || other.gameObject.CompareTag("Caravana"))
            {
                WolfArray[i].SetActive(true);

                float distC = Vector3.Distance(Caravana.position, WolfArray[i].transform.position);
                Debug.LogWarning("DistC: " + distC);
                float distP = Vector3.Distance(Player.position, WolfArray[i].transform.position);
                Debug.LogWarning("DistP: " + distP);
                if (distC >= distP)
                {
                    Nav = WolfArray[i].gameObject.GetComponent<GoAndNavigate>();
                    Nav.Target = Player;
                }
                else
                {
                    Nav = WolfArray[i].gameObject.GetComponent<GoAndNavigate>();
                    Nav.Target = Caravana;
                }
                this.gameObject.SetActive(false);
            }
        }
    }
}
