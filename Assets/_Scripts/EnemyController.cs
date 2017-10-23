using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject Enemigo;
    // Use this for initialization
    void Start () {
        Enemigo= GameObject.FindWithTag("Enemigo");
        Enemigo.SetActive(false);
    }

    public void PerseguirLobo1()
    {
        Debug.LogWarning("Colision!!");
        Enemigo.SetActive(true);
    }

}
