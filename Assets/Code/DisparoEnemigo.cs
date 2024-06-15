using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DisparoEnemigo : MonoBehaviour
{
    public Transform controladorDisparo;

    public Animator animator;

    public float distanciaLinea;

    public LayerMask capaJugador;

    public bool jugadorEnRango;

    public GameObject balaEnemigo;

    public float tiempoEntreDisparos;

    public float tiempoUltimoDisparo;

    public float tiempoEsperaDisparo;



    private void Update()
    {
        jugadorEnRango = Physics2D.Raycast(controladorDisparo.position, transform.right, distanciaLinea, capaJugador);
        if (jugadorEnRango)
        {
            if (Time.time > tiempoEntreDisparos + tiempoUltimoDisparo)
            {
                tiempoUltimoDisparo = Time.time;
                Invoke(nameof(Disparar), tiempoEsperaDisparo);
            }

            animator.SetBool("attack", true);
        }
    }

    private void Disparar()
    {

        GameObject clone = Instantiate(balaEnemigo, controladorDisparo.position, balaEnemigo.transform.rotation);
        clone.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 15, ForceMode2D.Impulse);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorDisparo.position, controladorDisparo.position + transform.right * distanciaLinea);
        animator.SetBool("attack", false);
    }
}
