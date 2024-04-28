using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Jugador : MonoBehaviour
{
    // Start is called before the first frame update
    private float direccionx = 0;
    private float direcciony = 0;
    private int puntos;
    [SerializeField] private GameObject honguito;
    [SerializeField] private TextMeshProUGUI textoCantidadDosis;
    [SerializeField] private UnityEvent<string> OnScoreChange;
    private void Start()
    {
        puntos = 0;
        OnScoreChange.Invoke(puntos.ToString());
    }
    private void Mover()
    {
        direccionx = Input.GetAxis("Horizontal");
        direcciony = Input.GetAxis("Vertical");
        Vector3 posicion = transform.position + new Vector3(0.2f * direccionx, 0.2f * direcciony, 0f);
        posicion.x = Mathf.Clamp(posicion.x, -35.5f, 35.5f);
        posicion.y = Mathf.Clamp(posicion.y, -30, 20);
        transform.position = posicion;
    }
    void FixedUpdate()
    {
        Mover();
        AvisoDeRequisitoAlcanzado();
    }

    public void SumarPuntos()
    {
        puntos += 1;
        OnScoreChange.Invoke(puntos.ToString());
    }
    public int GetPuntos() { return puntos; }
    public void RestarPuntos()
    {
        puntos -= puntos;
        OnScoreChange.Invoke(puntos.ToString());
    }

    private void AvisoDeRequisitoAlcanzado()
    {
        if(honguito.GetComponent<Honguito>().GetVida() == puntos)
        {
            textoCantidadDosis.color = Color.green;
        }
        else
        {
            textoCantidadDosis.color = Color.yellow;
        }
    }
}
