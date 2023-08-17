using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public Transform turretHead; // Assign the turret head component in the prefab's hierarchy.
    public Transform firePoint; // Assign the fire point component in the prefab's hierarchy.
    public float rotationSpeed = 10f;
    public float fireRate = 1f;
    public GameObject bulletPrefab; // Replace with your bullet or projectile prefab.

    float detectionRange = 1000f; // Adjust this to your desired detection range.

    private Transform target;
    private float fireCooldown = 0f;

    void Update()
    {
        FindTarget();
        if (target != null)
        {
            RotateTurret();
            if (fireCooldown <= 0f)
            {
                Fire();
                fireCooldown = 1f / fireRate;
            }
        }
        fireCooldown -= Time.deltaTime;
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Tag your enemy objects with "Enemy".

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= detectionRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void RotateTurret()
    {
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * rotationSpeed).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        ProjectileMovement bulletScript = bullet.GetComponent<ProjectileMovement>();

        // Calculate the direction from the turret's fire point towards the target.
        Vector3 directionToTarget = (target.position - firePoint.position).normalized;

        // Launch the bullet in the calculated direction.
        bulletScript.Launch(directionToTarget);
    }
}