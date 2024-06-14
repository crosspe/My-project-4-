using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public float durationDead = 5f;
    public bool vivo = true;
    public Movimiento Personaje;
    public TextMeshProUGUI vida;
    public int salud = 1;
    public string Escena;
    public Rigidbody2D rb;
    public Animator animator;
    private float Horizontal;
    private bool isDead = false;
    private int heal = 1;
    public int cantidadDeVida = 11;
    public event EventHandler MuerteJugador;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float gravedad = rb.velocity.y;
        float h = Input.GetAxisRaw("Horizontal");
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("kill");
        }
        rb.velocity = new Vector2(h * 7, gravedad);
        animator.SetInteger("Velocidad", (int)h);

        if (h != 0)
            transform.localScale = new Vector3(h, 1, 1);
    }
    public void Hit()
    {
        heal = heal - 1;
        if (heal == 0) Destroy(this);
    }
    public void Die()
    {
        if (!isDead)
        {
            isDead = true;
            animator.SetBool("isDead", true);
        }
    }
    public void TomarDaño(int Daño)
    {
        cantidadDeVida -= Daño;
        if (cantidadDeVida <= 0)
        {
            animator.SetTrigger("dead");
            MuerteJugador?.Invoke(this, EventArgs.Empty);
            Destroy(this);
        }
    }
}
