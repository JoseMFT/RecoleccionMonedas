using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murosMovibles: MonoBehaviour {

    public float desplazamientoZ = 4.5f;
    float vuelta = -1f;
    public float distancia = 0.0f;

    private void Update () {

        if (distancia >= 4.5f) {
            vuelta = -1* vuelta;

        }

        if (distancia <= -4.5f) {
            vuelta = -1 * vuelta;

        }
        distancia = distancia + desplazamientoZ * Time.deltaTime * vuelta;
        transform.Translate (0f, 0f, desplazamientoZ * Time.deltaTime * vuelta);
        desplazamientoZ = 1.5f;
    }
}