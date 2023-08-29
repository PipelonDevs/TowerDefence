using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnEnemyHitProjectile : ProjectileMovement
{
    protected override void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
