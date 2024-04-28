using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Honguito : MonoBehaviour
{
    [SerializeField] private int vida;
    private float contadorCrecimiento = 0;
    private float contadorAux = 0;
    private int umbralCrecimiento = 20;
    private float factorIncrementoEscala = 0.2f;
    [SerializeField] private GameObject[] arregloFungicidas1;
    [SerializeField] private GameObject[] arregloFungicidas2;

    [SerializeField] private UnityEvent<string> OnHealthChange;
    // Start is called before the first frame update
    void Start()
    {
        OnHealthChange.Invoke(vida.ToString());
        for (int i  = 0;i < arregloFungicidas1.Length;i++)
        {
            arregloFungicidas1[i].SetActive(false);
        }

        for (int i = 0; i < arregloFungicidas2.Length; i++)
        {
            arregloFungicidas2[i].SetActive(false);
        }

        for(int i = 0; i < 4; i++)
        {
            arregloFungicidas1[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Extinguir();
        Crecimiento();
    }
    void Crecimiento()
    {
        
        float aumentoTamano = factorIncrementoEscala * Time.deltaTime;
        contadorCrecimiento += Time.deltaTime;
        contadorAux += Time.deltaTime;
        gameObject.transform.localScale += new Vector3(aumentoTamano, aumentoTamano, aumentoTamano);
        if (contadorCrecimiento >= umbralCrecimiento)
        {
            vida++;
            OnHealthChange.Invoke(vida.ToString());
            contadorCrecimiento = 0;
            AparicionBasadaEnCrecimiento();
        }
        if(contadorAux >= 21)
        {
            umbralCrecimiento = 10;
        }
    }
    void RestarVida(int puntos)
    {
        vida -= puntos;
        OnHealthChange.Invoke(vida.ToString());
    }

    public int GetVida() { return vida; }
    void Extinguir()
    {
        if (vida <= 0)
        {
            OnHealthChange.Invoke(vida.ToString());
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RestarVida(collision.transform.GetComponent<Jugador>().GetPuntos());
            collision.transform.GetComponent<Jugador>().RestarPuntos();
        }
    }
    private void AparicionBasadaEnCrecimiento()
    {
        if (contadorAux <= 51)
        {
            AparecerFungicidaPrimerAnillo();
        } else
        {
            AparecerFungicidaSegundoAnillo();
        }
    }
    private void AparecerFungicidaPrimerAnillo()
    {
        if(20 < contadorAux && contadorAux < 21)
        {
            arregloFungicidas1[4].SetActive(true);
        }
        else
        {
            if(30 < contadorAux && contadorAux < 31)
            {
                arregloFungicidas1[5].SetActive(true);
            }
            else
            {
                if(40 < contadorAux && contadorAux < 41)
                {
                    arregloFungicidas1[6].SetActive(true);
                }
                else
                {
                    if(50 < contadorAux && contadorAux < 51)
                    {
                        arregloFungicidas1[7].SetActive(true);
                    }
                }
            }
        }
    }

    private void AparecerFungicidaSegundoAnillo()
    {
        if (60 < contadorAux && contadorAux < 61)
        {
            arregloFungicidas2[0].SetActive(true);
        }
        else
        {
            if (70 < contadorAux && contadorAux < 71)
            {
                arregloFungicidas2[1].SetActive(true);
            }
            else
            {
                if (80 < contadorAux && contadorAux < 81)
                {
                    arregloFungicidas2[2].SetActive(true);
                }
                else
                {
                    if (90 < contadorAux && contadorAux < 91)
                    {
                        arregloFungicidas2[3].SetActive(true);
                    }
                    else
                    {
                        if (100 < contadorAux && contadorAux < 101)
                        {
                            arregloFungicidas2[4].SetActive(true);
                        }
                        else
                        {
                            if(110 < contadorAux && contadorAux < 111)
                            {
                                arregloFungicidas2[5].SetActive(true);
                            }
                            else
                            {
                                if(120 < contadorAux && contadorAux < 121)
                                {
                                    arregloFungicidas2[6].SetActive(true);
                                }
                                else
                                {
                                    if (130 < contadorAux && contadorAux < 131)
                                    {
                                        arregloFungicidas2[7].SetActive(true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
