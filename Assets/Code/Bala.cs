using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public GameObject bala;

    // Update is called once per frame
    void Update()
    {
        float direccion = transform.localScale.x;
        Vector3 orientacion = new Vector3(direccion, 0, 0);
        Vector2 pos = transform.position + orientacion;

        GameObject clone = Instantiate(bala, pos, bala.transform.rotation);
        clone.GetComponent<Rigidbody2D>().velocity = new Vector2 (-5, 0);

        Destroy(clone, 2f);
    }
}
