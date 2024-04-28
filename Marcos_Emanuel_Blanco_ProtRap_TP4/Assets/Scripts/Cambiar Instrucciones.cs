using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CambiarInstrucciones : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoInstrucciones;
    [SerializeField] private GameObject honguito;

    void Update()
    {
        DesactivarTexto();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            textoInstrucciones.text = "Recolectá los fungicidas para derribar al hongo antes de que se acabe el tiempo y haya crecido demasiado. Siempre habrá una cantidad de dosis igual a la vida restante del hongo.";
        }
    }

    void DesactivarTexto()
    {
        if (!honguito.activeInHierarchy)
        {
            textoInstrucciones.gameObject.SetActive(false);
        }
    }
}
