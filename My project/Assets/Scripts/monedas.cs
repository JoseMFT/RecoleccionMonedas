/* Este c�digo hace rotar las monedas en el juego, a la vez que ordena su
 * destrucci�n una vez entran en contacto con el jugador. */

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

    void Update() {
        transform.Rotate (0.0f, 0.0f, velocidadRotacion * Time.deltaTime);
    }
    void OnTriggerEnter (Collider jugador) {
        if (jugador.tag == "Player") {
            Destroy (Moneda, 0.25f); //La coma despu�s del GameObject a destruir, define cuanto tiempo pasar� desde que se ejecuta la l�nea de c�digo hasta que se destruye la moneda.
        }
    }
}
