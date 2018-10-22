using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainRocketProjectile : MonoBehaviour
{

    public Rigidbody mainRocket;
    public float speed;
    public float explosionForce;
    public ParticleSystem explosionEffect;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {
        Object other = collision.collider.GetComponent<Rigidbody>();
        if (other)
        {
            Explode();
            ExplosionEffect();
        }

    }
    void Explode()
    {
        mainRocket.AddExplosionForce(explosionForce, transform.position, 5, 5, ForceMode.Impulse);
        Destroy(gameObject);
    }
    void ExplosionEffect()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(explosionEffect, 5);
    }
}
