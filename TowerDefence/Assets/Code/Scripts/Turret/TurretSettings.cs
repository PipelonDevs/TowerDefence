using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Turret", menuName = "Custom/Turret")]
public class TurretSettings : ScriptableObject
{
    public float rotationSpeed;
    public float fireRate;
    public GameObject bulletPrefab;
    public float detectionRange; // Adjust this to your desired detection range.
}
