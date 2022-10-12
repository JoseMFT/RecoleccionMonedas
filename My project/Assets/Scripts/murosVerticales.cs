using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murosVerticales : MonoBehaviour
{
    public float desplazamientoY = 15f;
    float vuelta = -1;
    public float distancia = 0.0f;
    [SerializeField]
    float comienzo = 1f;

    private void Update () {
        if (comienzo > 0f) {
            comienzo = comienzo - Time.deltaTime;
        }
        if (comienzo <= 0f) {
            if (distancia >= 5f) {
                vuelta = -1 * vuelta;

            }
            if (distancia <= 0f) {
                vuelta = -1 * vuelta;

            }
            distancia = distancia + desplazamientoY * Time.deltaTime * vuelta;
            transform.Translate (0f, desplazamientoY * Time.deltaTime * vuelta, 0f);
            desplazamientoY = 1.5f;
        }
    }
}