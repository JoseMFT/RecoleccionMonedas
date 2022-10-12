/*Este código hace de pantalla de incio y transporta al jugador a la escena principal
 * al hacer clic sobre el botón que dice "Comenzar". */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour {    
    public void ClickEnIniciar () { // Al hace clic sobre el botón de la pantalla de inicio, se pasará a la siguiente escena.
        Debug.Log ("Ha comenzado");
        SceneManager.LoadScene (1);
    }    
}
