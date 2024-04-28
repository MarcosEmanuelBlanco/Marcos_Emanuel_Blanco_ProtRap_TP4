using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> OnTimeChange;
    [SerializeField] private UnityEvent<string> OnTotalTimeChange;
    [SerializeField] private TextMeshProUGUI textoFinJuego;
    [SerializeField] private TextMeshProUGUI textoTiempoFinal;
    [SerializeField] private TextMeshProUGUI textoNivelCompletado;
    private float tiempo = 0;
    private bool reinicio;
    [SerializeField] private GameObject honguito;
    // Start is called before the first frame update
    void Start()
    {
        tiempo = 0;
        OnTimeChange.Invoke(tiempo.ToString());
        OnTotalTimeChange.Invoke(tiempo.ToString());
        textoFinJuego.gameObject.SetActive(false);
        textoNivelCompletado.gameObject.SetActive(false);
        textoTiempoFinal.gameObject.SetActive(false);
        reinicio = false;
    }

    // Update is called once per frame
    void Update()
    {
        RestarTiempo();
        FinDeJuego();
        ReiniciarEscena();
        SiguienteNivel();
        NivelCompletado();
        CerrarApp();
    }

    void RestarTiempo()
    {
        tiempo += Time.deltaTime;
        Mathf.Round(tiempo);
        OnTimeChange.Invoke(tiempo.ToString());
        OnTotalTimeChange.Invoke(tiempo.ToString());
    }

    void FinDeJuego()
    {
        if (tiempo >= 140)
        {
            Time.timeScale = 0;
            textoFinJuego.gameObject.SetActive(true);
            reinicio = true;
        }
    }

    void NivelCompletado()
    {
        if (!honguito.activeInHierarchy)
        {
            Time.timeScale = 0;
            textoNivelCompletado.gameObject.SetActive(true);
            textoTiempoFinal.gameObject.SetActive(true);
            reinicio = true;
        }
    }
    void ReiniciarEscena()
    {
        if (reinicio && Input.GetKeyDown(KeyCode.R))
        {    
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            reinicio = false;
            honguito.SetActive(true);
        }
    }

    void SiguienteNivel()
    {
        if(reinicio && Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 1)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            reinicio = false;
            honguito.SetActive(true);
        }
    }

    void CerrarApp()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
