using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ControladorHUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoPuntos;
    [SerializeField] private TextMeshProUGUI textoTiempo;
    [SerializeField] private TextMeshProUGUI textoTiempoFinal;
    [SerializeField] private TextMeshProUGUI textoVidaHonguito;
    public void ActualizarTextoPuntos(string nuevoTexto)
    {
        textoPuntos.text = "Dosis actuales: " + nuevoTexto;
    }

    public void ActualizarTextoTiempo(string nuevoTexto)
    {
        textoTiempo.text = "Tiempo: " + nuevoTexto;
    }
    public void ActualizarTextoTiempoFinal(string nuevoTexto)
    {
        textoTiempoFinal.text = "Tu Tiempo Final: " + nuevoTexto;
    }

    public void ActualizarTextoVidaHonguito(string nuevoTexto)
    {
        textoVidaHonguito.text = "Vida del hongo: " + nuevoTexto;
    }
}
