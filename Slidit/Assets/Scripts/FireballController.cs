using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private CircleCollider2D circleCollider2D;
    private const float RotationSpeed = 90f;
    private const float baseAngle = 0f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private GameObject sprite;
    [SerializeField] private Color baseColor;
    [SerializeField] private Color extuinguishedColor;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
        Input.gyro.enabled = true;
    }

    void Update()
    {
        Vector2 force = new Vector2(Input.acceleration.x, -Input.acceleration.z);
        Debug.Log(force);
        rb2d.velocity += force;
        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        if(force.y >0.7)
        {
            GetComponentInChildren<SpriteRenderer>().color = baseColor;
            circleCollider2D.enabled = true;
        }
        else if(force.y < -0.7)
        {
            GetComponentInChildren<SpriteRenderer>().color = extuinguishedColor;
            circleCollider2D.enabled = false;
        }

    }

}
