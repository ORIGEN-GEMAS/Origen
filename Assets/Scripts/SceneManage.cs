using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneManage : MonoBehaviour
{
    private AudioManager sfx; //Esta linea se puede borrar para no tener conflictos en otros proyectos

    private void Start()
    {
        // Metodo para buscar un audio e inicializarlo
        sfx = FindObjectOfType<AudioManager>(); //Esta linea se puede borrar para no tener conflictos en otros proyectos
    }

    //Codigo de cambio de escena🔁
    public void ChangeScence(string Scena)
    {
        sfx.PlaySFX(sfx.click); //Esta linea se puede borrar para no tener conflictos en otros proyectos
        SceneManager.LoadScene(Scena);
    }
    //Boton de pausa 🛑
    public void Stop() 
    {
        sfx.PlaySFX(sfx.click); //Esta linea se puede borrar para no tener conflictos en otros proyectos
        Time.timeScale = 0;
        Debug.Log("Pausado");
    }
    //Boton de continuar ⏩
    public void Continue()
    {
        sfx.PlaySFX(sfx.click); //Esta linea se puede borrar para no tener conflictos en otros proyectos
        Time.timeScale = 1;
        Debug.Log("Continuado");
    }
    //Boton de Reiniciar 🔁
    public void Restart()
    {
        sfx.PlaySFX(sfx.click); //Esta linea se puede borrar para no tener conflictos en otros proyectos
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Reiniciado");
    }
    //Boton de Cerrar ❌
    public void Cerrar()
    {
        sfx.PlaySFX(sfx.click); //Esta linea se puede borrar para no tener conflictos en otros proyectos
        Application.Quit();
        Debug.Log("Cerrado");
    }
}
