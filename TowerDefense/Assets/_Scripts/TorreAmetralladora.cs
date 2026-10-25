using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorreAmetralladora : TorreBase
{

    public int balasPorRafaga = 5;
    public float intervaloDisparos = 0.15f;

    private bool disparando = false;

    public override void Disparar()
    {
        if (enemigo == null || disparando)
        {
            return;
        }

        StartCoroutine(DispararRafaga());
    }
    private IEnumerator DispararRafaga()
    {
        disparando = true;
        for (int i = 0; i< balasPorRafaga; i++)
        {
            if(enemigo == null)
            {
                break;
            }

            base.Disparar();
            yield return new WaitForSeconds(intervaloDisparos);
        }

        disparando = false;
    }
}
