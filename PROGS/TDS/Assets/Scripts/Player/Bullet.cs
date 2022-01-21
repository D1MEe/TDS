using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float startlifetime;
    public float distance;
    public int damage;
    public LayerMask WhatIsSolid;


    void Start()
    {
        
    }


    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, WhatIsSolid);
        if(hitInfo.collider != null)
        {
            if (lifetime > 0)
            {
                lifetime -= Time.deltaTime;
            }
            else
            {
                Destroy(gameObject);
                lifetime = startlifetime;
            } 
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
