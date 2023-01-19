using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    public int damage = 1;



    void Start()
    {
        rb.velocity = transform.right * speed;
    }
     void OnTriggerEnter2D(Collider2D collision)
    {
        patrol enemy = collision.GetComponent<patrol>();

        if (collision.CompareTag("Enemy"))
        {
            enemy.takeDamage(damage);
        }
        Destroy(gameObject);
    }

}
