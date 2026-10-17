using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleada;

    private int enemigosDuranteEStaOleada;

    public delegate void OleadaTerminada();
    public event OleadaTerminada EnOleadaTerminada;
    void Start()
    {
        oleada = 0;
        ConfigurarCantidadDeEnemigos();
        InstanciarEnemigo();
    }

    private void TerminarOla()
    {
        if (EnOleadaTerminada != null)
        {
            EnOleadaTerminada();
        }
    }

    public void ConfigurarCantidadDeEnemigos()
    {
        enemigosDuranteEStaOleada = enemigosPorOleada[oleada];
    }

    public void InstanciarEnemigo()
    {
        int indiceAleatorio = Random.Range(0, prefabsEnemigos.Count);
        Instantiate<GameObject>(prefabsEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        enemigosDuranteEStaOleada--;
        if (enemigosDuranteEStaOleada < 0) 
        {
            oleada++;
            ConfigurarCantidadDeEnemigos();
            TerminarOla();
            return;
        }
        Invoke("InstanciarEnemigo", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
