using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingExplosiveProjectile : ProjectileMovement
{
    public float bounceForce = 5f;      
    public GameObject explosionPrefab;  
    public float explosionDelay = 1f;   

    private bool hasBounced = false;    

    protected override void OnCollisionEnter(Collision collision)
    {

        if (!hasBounced && collision.gameObject.CompareTag("Enemy"))
        {
            hasBounced = true;

            // Apply a bounce force to the projectile in the opposite direction of the collision.
            rb.useGravity = true;
            rb.velocity = Vector3.Reflect(rb.velocity, collision.contacts[0].normal) * bounceForce;
           
            StartCoroutine(ExplodeAfterDelay());
        }
    }

    private IEnumerator ExplodeAfterDelay()
    {
        yield return new WaitForSeconds(explosionDelay);

        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
