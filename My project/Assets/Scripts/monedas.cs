using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedas : MonoBehaviour
{
    [SerializeField]
    float velocidadRotacion = 15f;
    [SerializeField]
    GameObject Moneda;
    [SerializeField]
    GameObject prefabParticles;

    void Update()
    {
        transform.Rotate (0.0f, 0.0f, velocidadRotacion * Time.deltaTime);
    }
    void OnTriggerEnter (Collider jugador) {
        if (jugador.tag == "Player") {
            Destroy (Moneda, 0.75f);
        }
    }
}
