using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{

    private Rigidbody2D rb2d;

    private int speed = 20;
    private int minSpeed = 10;
    private int maxSpeed = 50;

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(speed, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-speed, -15));
        }
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    private void Update()
    {
        if (rb2d.velocity.x > 0)
        {
            speed = Random.Range(minSpeed, maxSpeed);
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
        } else if (rb2d.velocity.x < 0)
        {
            speed = Random.Range(-minSpeed, -maxSpeed);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        Debug.Log(speed);
    }
}
