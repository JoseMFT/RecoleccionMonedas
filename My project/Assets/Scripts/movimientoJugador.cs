/* Este código controla las funciones principales del jugador, como el movimiento,
 * el tiempo que pasa en partida, o el número de monedas que recoge, así como controlar
 * la música de fondo, y generar la pantalla de victoria llegado el momento. */

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
    
    void Start () {
        sphere = GetComponent<Rigidbody> ();
        Respawn = transform.position; // El juego toma la posición del jugador en el primer frame para luego usarla como respawn en caso de que el jugador salga del mapa.
    }

    void Update () {
        if (jugando != false) {
            tiempoSegundos = tiempoSegundos + Time.deltaTime;
        }
        if (tiempoSegundos >= 60f) { // Cada 60 segundos el número de minutos aumenta, y el número de segundos se reinicia a 0.
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
            Instantiate (prefabParticles, choque.transform.position, choque.transform.rotation); // Se generan partículas cuando el jugador toca una moneda.
        }
        if (choque.tag == "Respawn") { // Plataforma debajo del mapa que al ser tocada envía al jugador a su posición de inicio.
            transform.position = Respawn;
        }
    }

    private void FixedUpdate () {
        sphere.AddForce (movimiento, ForceMode.Impulse);
    }

    public void ClickEnMusica () {
        Debug.Log ("Ha silenciado la música"); // Pausa y continúa sonando la música cada vez que se hace clic sobre la casilla donde dice "Música".
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
