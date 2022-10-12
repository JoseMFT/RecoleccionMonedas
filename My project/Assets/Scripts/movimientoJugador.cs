using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class movimientoJugador: MonoBehaviour {
    
    float tiempoSegundos = 0f;
    int tiempoMinutos = 0;
    bool Play = true;
    bool jugando = true;
    int contadorMonedas = 0;
    Rigidbody sphere;
    Vector3 movimiento;
    Vector3 Respawn;

    [SerializeField]
    float Impulse = 60f;
    [SerializeField]
    GameObject musicaJuego;
    [SerializeField]
    TextMeshProUGUI totalTiempo;    
    [SerializeField]
    GameObject prefabParticles;
    [SerializeField]
    GameObject finalDePartida;
    [SerializeField]
    GameObject canvasFinal;
    
    
    
    // Start is called before the first frame update
    void Start () {
        sphere = GetComponent<Rigidbody> ();
        Respawn = transform.position;
    }

    // Update is called once per frame
    void Update () {

        if (jugando != false) {
            tiempoSegundos = tiempoSegundos + Time.deltaTime;
        }

        if (tiempoSegundos >= 60f) {
            ++tiempoMinutos;
            tiempoSegundos = 0;
        }
        movimiento.x = Input.GetAxis ("Horizontal") * Time.deltaTime * Impulse;
        movimiento.z = Input.GetAxis ("Vertical") * Time.deltaTime * Impulse * 0.75f;
        if (contadorMonedas == 15) {
            canvasFinal.SetActive (true);
            jugando = false;
            totalTiempo.text = tiempoMinutos.ToString () + " minutos y " + tiempoSegundos.ToString ("00") + " segundos";
        }
    }

    void OnTriggerEnter (Collider choque) {
        if (choque.tag == "Tokens") {
            ++contadorMonedas;
            Debug.Log (contadorMonedas);
            choque.GetComponent<AudioSource> ().Play ();
            Instantiate (prefabParticles, choque.transform.position, choque.transform.rotation);
        }
        if (choque.tag == "Respawn") {
            transform.position = Respawn;
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
