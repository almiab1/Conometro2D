using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conometro : MonoBehaviour
{
    // Atributos
    private float startTime;

    // Propriedades
    public float StartTime { get => startTime; set => startTime = value; }

    // UI
    public Text conometro;

    // Tiempo
    object[] tiempo = new object[4];

    // Controlador conometro
    bool estaActivo;
    bool esLaPrimeraVez;

    // Start
    void Start()
    {
        tiempo[0] = "00";
        tiempo[1] = "00";
        tiempo[2] = "00";
        tiempo[3] = "00";
    }
    // Update
    void Update()
    {
        if (estaActivo == true) mostrarPorPantalla();
    }

    // dimeTiempo() --> object
    object[] dimeTiempo()
    {
        float controladorTiempo = Time.time - StartTime;

        object[] ultimoTiempo = new object[4];

        // horas
        ultimoTiempo[0] = (controladorTiempo / 3600).ToString("00");
        // min
        ultimoTiempo[1] = ((controladorTiempo / 60) % 60).ToString("00");
        // seg
        ultimoTiempo[2] = (controladorTiempo % 60).ToString("00");
        // milis
        ultimoTiempo[3] = ((controladorTiempo * 100) % 100).ToString("00");
        Debug.Log(ultimoTiempo[3]);

        return ultimoTiempo;
    }
    // empezarContar()
    public void empezarAContar()
    {
        estaActivo = true;
        if (esLaPrimeraVez == true)
        {
            StartTime = Time.time;
            esLaPrimeraVez = false;

        }
        else
        {
            Time.timeScale = 1;
        }
        mostrarPorPantalla();
    }

    // mostrarPorPantall()
    void mostrarPorPantalla()
    {
        tiempo = dimeTiempo();
        conometro.text = string.Format("{00}:{01}:{02}:{03}", tiempo[0], tiempo[1], tiempo[2], tiempo[3]); //codifica el formato tiempo
    }

    // pausarTiempo()
    public void pausarTiempo()
    {
        Time.timeScale = 0;
        estaActivo = false;
    }
}
