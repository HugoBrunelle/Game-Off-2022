using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0.5f;
    public static float damage = 50f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<FatMama>();
        if (enemy != null)
        {
            enemy.GetHurt(Bullet.damage);
            Destroy(gameObject);
        }
    }
}
