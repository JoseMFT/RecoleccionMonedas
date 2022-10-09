using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    [SerializeField]
    float Impulse = 150f;
    Rigidbody sphere;
    Vector3 movimiento;
    Vector3 rotacion;
    int contadorMonedas = 0;
    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        movimiento.x = Input.GetAxis ("Horizontal") * Time.deltaTime * Impulse;
        movimiento.z = Input.GetAxis ("Vertical") * Time.deltaTime * Impulse;
    }

    void OnTriggerEnter (Collider choque) {
        if (choque.tag == "Tokens") {
            ++contadorMonedas;
            Debug.Log (contadorMonedas);
        }
    }

    private void FixedUpdate () {
        sphere.AddForce (movimiento, ForceMode.Impulse);
    }
}
 