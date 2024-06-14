using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemigo : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float velocidad;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento(); 
        Vuelta();
        
    }
    void Movimiento()
    {

        rb2d.velocity = new Vector2(velocidad, rb2d.velocity.y);
    }
    void Vuelta()
    {
        if (velocidad < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("patrullaje"))
        {
            velocidad *= -1;
        }
    }
}
