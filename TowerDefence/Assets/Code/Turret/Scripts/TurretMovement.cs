using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretMovement : MonoBehaviour
{
    public Transform turretHead; // Assign the turret head component in the prefab's hierarchy.
    public Transform firePoint; // Assign the fire point component in the prefab's hierarchy.
    public TurretSettings settings;

    

    private Transform _target;
    private float _fireCooldown = 0f;

    void Update()
    {
        FindTarget();
        if (_target != null)
        {
            RotateTurret();
            if (_fireCooldown <= 0f)
            {
                Fire();
                _fireCooldown = 1f / settings.fireRate;
            }
        }
        _fireCooldown -= Time.deltaTime;
    }

    void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Tag your enemy objects with "Enemy".

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance && distanceToEnemy <= settings.detectionRange)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }
    }

    void RotateTurret()
    {
        Vector3 direction = _target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(turretHead.rotation, lookRotation, Time.deltaTime * settings.rotationSpeed).eulerAngles;
        turretHead.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Fire()
    {
        GameObject bullet = Instantiate(settings.bulletPrefab, firePoint.position, firePoint.rotation);
        ProjectileMovement bulletScript = bullet.GetComponent<ProjectileMovement>();

        // Calculate the direction from the turret's fire point towards the target.
        Vector3 directionToTarget = (_target.position - firePoint.position).normalized;

        // Launch the bullet in the calculated direction.
        bulletScript.Launch(directionToTarget);
    }
}