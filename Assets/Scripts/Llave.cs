using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour
{
    GameObject[] obstaculos;

    void Start()
    {
        obstaculos = GameObject.FindGameObjectsWithTag("ObstaculoFlotante");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Choqué con jugador");
            gameObject.SetActive(false);

            foreach (GameObject obstaculo in obstaculos)
            {
                Transform obstaculoTransform = obstaculo.GetComponent<Transform>();
                obstaculoTransform.Translate(Vector3.up * 4f);
            }
        }
    }
}
