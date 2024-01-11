using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletData bulletData;

    private Vector2 startPosition;
    private float conquareDistance = 0;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    } 
    public void Initialize()
    {
        startPosition = transform.position;
        rb2d.velocity = transform.right * this.bulletData.speed;
    }

    public void Update()
    {
        conquareDistance = Vector2.Distance(transform.position, startPosition);
        if (conquareDistance >= bulletData.maxDistance ) 
        {
            DisableObject();
        }
    }

    private void DisableObject()
    {
        rb2d.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collidered" + collision.name);

        var damagable = collision.GetComponent<Damagable>();
        if (damagable != null)
        {
            damagable.Hit(bulletData.damage);
        }

        DisableObject();
    }
}
