// Este c�digo hace girar obst�culos.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murosRotatorios : MonoBehaviour
{
    float velocidadRotacion = 35f;

    void Update()
    {
        transform.Rotate (0f, velocidadRotacion * Time.deltaTime, 0f);
    }
}
