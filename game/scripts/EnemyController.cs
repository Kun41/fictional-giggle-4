using System.Collections;
using System.Collections.Generic;
using UnityEngine;

﻿public class EnemyController : MonoBehaviour
{
    // Hraði hreyfingar
    public float speed;
    // Stefna hreyfingar (lóðrétt eða lárétt)
    public bool vertical;
    // Tími milli stefnisbreytinga
    public float changeTime = 3.0f;

    // Breyta sem segir til um hvort óvinurinn sé skemmdur eða ekki
    bool broken = true;

    Rigidbody2D rigidbody2D;
    // Reyksekt
    public ParticleSystem smokeEffect;
    // Sprenghlaðan
    public ParticleSystem boom;
    float timer;
    // Stefna hreyfingar (1 eða -1)
    int direction = 1;
    Animator animator;
    // Start er kallað í byrjun
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Ef óvinurinn er ekki skemmdur, hætt er við
        if(!broken)
        {
            return;
        }
        timer -= Time.deltaTime;

        // Ef tíminn er orðinn minni en 0
        if (timer < 0)
        {
            // Breyti stefnu hreyfingar
            direction = -direction;
            timer = changeTime;
        }
    }
    
    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
          // Ef óvinurinn er ekki skemmdur, hætt er við
        if(!broken)
        {
            return;
        }
        if (vertical)
        {
            // Set stefnuhreyfingar í animator
            animator.SetFloat("movex", 0);
            animator.SetFloat("movey", direction); 
            position.y = position.y + Time.deltaTime * speed * direction;;
        }
        else
        {
            // Set stefnuhreyfingar í animator
            animator.SetFloat("movex", direction);
            animator.SetFloat("movey", 0);
            position.x = position.x + Time.deltaTime * speed * direction;;
        }
        
        rigidbody2D.MovePosition(position);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController >();

        if (player != null)
        {
            // Mínka líf leikmanns ef það snertist við óvin
            player.ChangeHealth(-1);
        }
    }
    // Fall sem lagar óvininn
    public void Fix()
    {
        // Spila sprenghlaðan
        boom.Play();
        // Segja animator að spila lagaða stöðu
        animator.SetTrigger("fixed");
        // Merkja óvininn sem lagaðan
        broken = false;
        // Slekkja í rigidbody
        rigidbody2D.simulated = false;
        // Slekkja í reyksekt
        smokeEffect.Stop();
    }
}
