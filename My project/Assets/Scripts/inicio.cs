using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class inicio : MonoBehaviour
{
    public void ClickEnIniciar () {
        Debug.Log ("Ha comenzado");
        SceneManager.LoadScene (1);
    }    
}
