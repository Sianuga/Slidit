using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Vector2 force = new Vector2(Input.acceleration.x, -Input.acceleration.z);
        Debug.Log(force);
        rb2d.AddForce(force);
    }
}
