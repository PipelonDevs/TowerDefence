using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float bulletSpeed = 10f; // Adjust this to control the bullet's speed.

    protected Rigidbody rb; // Reference to the Rigidbody component.

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called when the bullet is spawned.
    public virtual void Launch(Vector3 direction)
    {
        rb.velocity = direction * bulletSpeed; // Set the initial velocity.
     //  Destroy(gameObject, 10f);
    }

    // Called when the bullet collides with something.
    protected virtual void OnCollisionEnter(Collision collision)
    {
 
    }
}
