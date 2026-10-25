using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bala : MonoBehaviour, IAtacante
{

    public Vector3 destino;
    public float velocidad = 20;
    public GameObject enemigo;
    public int dano = 10;

    void Start()
    {
        destino.y += 1;
    }

    void Update()
    {
        var paso = velocidad * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destino, paso);
        if (Vector3.Distance(transform.position, destino) < 0.01f)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BALA COLISIONÓ CON: " +
             collision.gameObject.name +
             " | Tag: [" + collision.gameObject.tag + "]");


        if (collision.gameObject.tag == "Enemigo")
        {
            enemigo = collision.gameObject;
            Danar(dano);
            Destroy(gameObject);
        }
    }

    public void Danar(int _dano = 0)
    {
        enemigo.GetComponent<EnemigoBase>().RecibirDano(_dano);
    }
    
}
