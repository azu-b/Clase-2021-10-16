using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoVolador : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform objA;
    public Transform objB;
    public Transform obj;

    bool patrullando = true;
    bool caminandoHaciaA = true;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (patrullando) // Está patrullando
        {
            if (nav.remainingDistance <= 2.2f) // Ya está cerca de su objetivo
            {
                // Cambiar a qué punto va
                if (caminandoHaciaA) // Si llega al punto A
                {
                    nav.SetDestination(objB.position); // Ahora va al B
                    caminandoHaciaA = false;
                } else
                {
                    nav.SetDestination(objA.position); // Ahora va al A
                    caminandoHaciaA = true;
                }
            }
        } else
        {
            nav.SetDestination(obj.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Inicia la persecución");
            patrullando = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("Deja la persecución");
            patrullando = true;
        }
    }
}
