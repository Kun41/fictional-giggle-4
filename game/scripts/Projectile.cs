using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        // Nær í Rigidbody2D komponentinn á þessari leikhlut.
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force)
    {
        // Bætir öfl við hlutinn til að hreyfa hann í ákveðna átt með ákveðnu magni.
        rigidbody2d.AddForce(direction * force);
    }

    void Update()
    {
        // Ef fjarlægð frá upphafsstað er stærri en 1000.0f eyðir þessum leikhlut.
        if (transform.position.magnitude > 1000.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Ef hlutur sem klessir á leikhlutinn er óvinur, kallar á fallið Fix() í EnemyController.
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }

        // Eyðir þessum leikhlut.
        Destroy(gameObject);
    }
}
