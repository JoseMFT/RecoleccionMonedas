using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class movimientoJugador: MonoBehaviour {
    [SerializeField]
    float Impulse = 150f;
    [SerializeField]
    float Sensitivity = 10f;
    [SerializeField]
    GameObject musicaJuego;
    bool Play = true;
    [SerializeField]
    GameObject prefabParticles;
    [SerializeField]
    GameObject finalDePartida;
    [SerializeField]
    GameObject canvasFinal;
    
    Rigidbody sphere;
    Vector3 movimiento;

    int contadorMonedas = 0;
    // Start is called before the first frame update
    void Start () {
        sphere = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        movimiento.x = Input.GetAxis ("Horizontal") * Time.deltaTime * Impulse;
        movimiento.z = Input.GetAxis ("Vertical") * Time.deltaTime * Impulse * 0.75f;

        if (contadorMonedas == 15) {
            canvasFinal.SetActive (true);
        }
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

    public void ClickEnMusica () {
        Debug.Log ("Ha silenciado la música");
        if (Play == true) {
            Play = false;
            GetComponent<AudioSource> ().Pause ();
        } else if (Play == false) {
            Play = true;
            GetComponent<AudioSource> ().Play ();
        }
    }

    public void ClickEnBoton () {
        Debug.Log ("Ha clicado");
        SceneManager.LoadScene (0);
    }
}
