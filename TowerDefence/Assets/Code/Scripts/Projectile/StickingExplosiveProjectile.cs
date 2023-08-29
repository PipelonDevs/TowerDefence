using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickingExplosiveProjectile : ProjectileMovement
{
    public GameObject explosionPrefab;
    public float explosionDelay = 1f;
    private bool isStuck = false;

    protected override void OnCollisionEnter(Collision collision)
    {
        if (!isStuck && collision.gameObject.CompareTag("Enemy"))
        {

            isStuck = true;
           
            transform.parent = collision.transform; // Attach to the enemy
            GetComponent<Rigidbody>().isKinematic = true; // Disable physics

            // Start the explosion delay timer.
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
