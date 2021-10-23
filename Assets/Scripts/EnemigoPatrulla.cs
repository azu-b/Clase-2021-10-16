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
    public Transform jugador;

    bool estaPatrullando = true;
    enum Destino
    {
        PuntoA,
        PuntoB,
        PuntoC,
        Jugador
    }

    Destino destinoActual = Destino.PuntoA;
    Destino destinoOriginal;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.SetDestination(puntoA.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (nav.remainingDistance <= 2.2f)
        {
            if (estaPatrullando)
            {
                PatrullaNormal();
            } else
            {
                RestablecerDestinoOriginal();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && estaPatrullando)
        {
            destinoOriginal = destinoActual;
            destinoActual = Destino.Jugador;
            nav.SetDestination(jugador.position);
            estaPatrullando = false;
        }
    }

    void RestablecerDestinoOriginal()
    {
        destinoActual = destinoOriginal;

        if (destinoActual == Destino.PuntoA)
        {
            nav.SetDestination(puntoA.position);
        }
        else if (destinoActual == Destino.PuntoB)
        {
            nav.SetDestination(puntoB.position);
        }
        else if (destinoActual == Destino.PuntoC)
        {
            nav.SetDestination(puntoC.position);
        }

        estaPatrullando = true;
    }

    void PatrullaNormal()
    {
        if (destinoActual == Destino.PuntoA)
        {
            nav.SetDestination(puntoB.position);
            destinoActual = Destino.PuntoB;
        }
        else if (destinoActual == Destino.PuntoB)
        {
            nav.SetDestination(puntoC.position);
            destinoActual = Destino.PuntoC;
        }
        else if (destinoActual == Destino.PuntoC)
        {
            nav.SetDestination(puntoA.position);
            destinoActual = Destino.PuntoA;
        }
    }
}
