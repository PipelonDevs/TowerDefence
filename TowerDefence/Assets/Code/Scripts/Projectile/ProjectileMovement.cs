using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float bulletSpeed = 10f; // Adjust this to control the bullet's speed.

    private Rigidbody rb; // Reference to the Rigidbody component.

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Called when the bullet is spawned.
    public void Launch(Vector3 direction)
    {
        rb.velocity = direction * bulletSpeed; // Set the initial velocity.
        Destroy(gameObject, 3f); // Destroy the bullet after a certain time (e.g., 3 seconds).
    }

}
