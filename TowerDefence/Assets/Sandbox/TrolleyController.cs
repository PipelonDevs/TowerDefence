using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrolleyController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this to set the movement speed of the trolley
    private Rigidbody trolleyRigidbody;

    private void Start()
    {
        // Get the Rigidbody component attached to the trolley GameObject
        trolleyRigidbody = GetComponent<Rigidbody>();

        // Make sure the Rigidbody has proper constraints and settings
        trolleyRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        trolleyRigidbody.useGravity = false;
    }

    private void Update()
    {
        // Check for input to move the trolley forward
        float movementInput = Input.GetAxis("Vertical");

        // Calculate the movement vector based on the trolley's forward direction and input
        Vector3 movement = transform.forward * movementInput * moveSpeed * Time.deltaTime;

        // Apply the movement to the trolley's Rigidbody
        trolleyRigidbody.MovePosition(trolleyRigidbody.position + movement);
    }
}