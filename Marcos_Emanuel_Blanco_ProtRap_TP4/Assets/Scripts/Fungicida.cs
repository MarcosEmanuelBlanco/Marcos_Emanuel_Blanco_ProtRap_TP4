using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fungicida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<Jugador>().SumarPuntos();
            gameObject.SetActive(false);
        }
    }
}
