/*Este c�digo hace de pantalla de incio y transporta al jugador a la escena principal
 * al hacer clic sobre el bot�n que dice "Comenzar". */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour {    
    public void ClickEnIniciar () { // Al hace clic sobre el bot�n de la pantalla de inicio, se pasar� a la siguiente escena.
        Debug.Log ("Ha comenzado");
        SceneManager.LoadScene (1);
    }    
}
