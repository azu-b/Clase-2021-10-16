using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoPatrulla : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform puntoA;
    public Transform puntoB;
    public Transform puntoC;

    bool estaPatrullando = true;
    enum Destino
    {
        PuntoA,
        PuntoB,
        PuntoC,
        Jugador
    }

    Destino actual = Destino.PuntoA;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(puntoA.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (estaPatrullando)
        {
            if (nav.remainingDistance <= 2.2f)
            {
                if (actual == Destino.PuntoA)
                {
                    nav.SetDestination(puntoB.position);
                    actual = Destino.PuntoB;
                }
                else if (actual == Destino.PuntoB)
                {
                    nav.SetDestination(puntoC.position);
                    actual = Destino.PuntoC;
                }
                else if (actual == Destino.PuntoC)
                {
                    nav.SetDestination(puntoA.position);
                    actual = Destino.PuntoA;
                }
            }
        }
    }
}
