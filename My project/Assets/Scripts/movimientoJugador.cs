using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    [SerializeField]
    float Impulse = 15f;
    Rigidbody sphere;

    Vector3 movimiento;
    Vector3 velocidadPrevia;
    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<Rigidbody> ();
    }

    void limits () {
        if (movimiento.x > 15f) {
            movimiento.x = 15f;
        } else if (movimiento.z < -10f) {
            movimiento.z = -10f;
        }
    }

    void thrust () {
            movimiento.x = velocidadPrevia.x * Impulse * (-1.75f);
            movimiento.z = velocidadPrevia.z * Impulse * (-1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        limits ();
        movimiento.x = Input.GetAxis ("Vertical") * Time.deltaTime * Impulse;
        velocidadPrevia.x = movimiento.x;
        limits ();
        movimiento.z = Input.GetAxis ("Horizontal") * Time.deltaTime * -Impulse;
        velocidadPrevia.z = movimiento.z;

        if (movimiento.x <= 0f) {
            thrust ();
        } else if (movimiento.z<= 0f) {
            thrust ();
        }

    }

    private void FixedUpdate () {
        sphere.AddForce (movimiento, ForceMode.Impulse);
    }
}
