using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemigos : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos;
    public int oleada;
    public List<int> enemigosPorOleada;

    private int enemigosDuranteEStaOleada;

    public bool laOleadaHaIniciado;
    public List<GameObject> EnemigosGenerados;

    public delegate void EstadoOleada();
    public event EstadoOleada EnOleadaIniciada;
    public event EstadoOleada EnOleadaTerminada;
    public event EstadoOleada EnOleadaGanada;
    void Start()
    {
        oleada = 0;
    }

    private void FixedUpdate()
    {
        if (laOleadaHaIniciado && EnemigosGenerados.Count == 0)
        {
            GanarOla();
        }
    }

    public void EmpezarOleada()
    {
        if (laOleadaHaIniciado)
        {
            return;
        }
        ConfigurarCantidadDeEnemigos();
        laOleadaHaIniciado = true;
        InstanciarEnemigo();
        if (EnOleadaIniciada != null)
        {
            EnOleadaIniciada();
        }
    }

    private void GanarOla()
    {
        if (laOleadaHaIniciado && EnOleadaGanada != null)
        {
            EnOleadaGanada();
            laOleadaHaIniciado = false;
        }
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
        var enemigoTemporal = Instantiate<GameObject>(prefabsEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        EnemigosGenerados.Add(enemigoTemporal);

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
