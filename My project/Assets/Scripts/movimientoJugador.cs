using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador: MonoBehaviour {
    [SerializeField]
    float Impulse = 150f;
    [SerializeField]
    float Sensitivity = 10f;
    bool Play = true;
    [SerializeField]
    GameObject prefabParticles;
    //float JumpPower = 15f;
    //float recuperacionSalto;

    Rigidbody sphere;
    Vector3 movimiento;
    //Vector3 rotacion;
    int contadorMonedas = 0;
    // Start is called before the first frame update
    void Start () {
        sphere = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        movimiento.x = Input.GetAxis ("Horizontal") * Time.deltaTime * Impulse;
        movimiento.z = Input.GetAxis ("Vertical") * Time.deltaTime * Impulse * 0.75f;

        if (Input.GetKey ("left")) {
            transform.rotation = Quaternion.Euler(0f, - Sensitivity * Time.deltaTime, 0f);
        }

        if (Input.GetKey ("right")) {
            transform.rotation = Quaternion.Euler(0f, Sensitivity * Time.deltaTime, 0f);
        }
        /*salto.y = JumpPower * Time.deltaTime;
        if (Input.GetKey ("space")) {
            sphere.AddForce (salto, ForceMode.Impulse);
            recuperacionSalto = 5f;
            for (recuperacionSalto = 5f; recuperacionSalto == 0f;) {
                JumpPower = 0f;
                recuperacionSalto = recuperacionSalto - Time.deltaTime;
            }
            JumpPower = 15f;
            recuperacionSalto = 5f;
        }*/
    }

    void OnTriggerEnter (Collider choque) {
        if (choque.tag == "Tokens") {
            ++contadorMonedas;
            Debug.Log (contadorMonedas);
            choque.GetComponent<AudioSource> ().Play ();
            Instantiate (prefabParticles, choque.transform.position, choque.transform.rotation);
        }
    }

    private void FixedUpdate () {
        sphere.AddForce (movimiento, ForceMode.Impulse);
    }
}
