using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salto : MonoBehaviour
{
    public Animator animator;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D;
    private bool isGrounded;



    private void Start() 
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        //if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        //{
        //    animator.SetInteger("Jump", 0);
        //}
        //else
        //{
        //    animator.SetInteger("Jump", 1);
        //}
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            animator.SetBool("Jumping", true);
        }
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Suelo"))
        {
            isGrounded = true;
            animator.SetBool("Jumping", false);
        }
    }
}

