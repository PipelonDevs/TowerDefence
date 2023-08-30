using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyHealth : MonoBehaviour
{
    public float health;
    public float armor;
    public GameObject trolley;

    // Update is called once per frame
    void Update()
    {
        if (trolley == null)
            return;

        if (health <= 0)
            Destroy(trolley);
    }

    public void InflictDamage(float damage)
    {
        health -= System.Math.Max(damage - armor, 0);
        Debug.Log("Damage inflicted, health: " + health);
    }
}
