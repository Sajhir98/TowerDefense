using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 50;
    public int dano = 10;

    public Animator Anim;
    private NavMeshAgent agente;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();

        agente.SetDestination(objetivo.transform.position);
        Anim.SetBool("IsMoving", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Objetivo"))
        {
            agente.isStopped = true;

            Anim.SetBool("IsMoving", false);
            Anim.SetTrigger("OnObjectiveReached");

        }
    }


    public void Danar()
    {
        objetivo?.GetComponent<Objetivo>().RecibirDano(dano); 
    }

    public void RecibirDano(int danoRecibido = 5)
    {
        vida -= danoRecibido;

        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }
}
