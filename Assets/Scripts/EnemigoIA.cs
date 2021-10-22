using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoIA : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform obj;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // nav.remainingDistance // <--- Distancia para llegar al objetivo
        nav.SetDestination(obj.position); // Le actualizo en dónde está su objetivo
    }
}
