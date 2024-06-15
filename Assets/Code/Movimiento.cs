using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] private float speed;
    public Rigidbody2D rb;
    public Animator animator;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gravedad = rb.velocity.y;
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * speed, gravedad);

        animator.SetInteger("speed", (int)h);

        if(h != 0)
        {
            transform.localScale = new Vector3(h, 1, 1);
        }
    }
}
