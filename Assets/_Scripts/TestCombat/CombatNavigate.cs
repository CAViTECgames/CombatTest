﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CombatNavigate : MonoBehaviour {

    public Transform Target;
    NavMeshAgent myNav;

    // Use this for initialization
    void Start()
    {
        myNav = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        myNav.SetDestination(Target.position);

    }
}
