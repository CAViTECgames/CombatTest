using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemigo : MonoBehaviour{

    public EnemyController Trigger;

    private void OnTriggerEnter(Collider other)
    {
        Trigger.PerseguirLobo1();
    }
}

