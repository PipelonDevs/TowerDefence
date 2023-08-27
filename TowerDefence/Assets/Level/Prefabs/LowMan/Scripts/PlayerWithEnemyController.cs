using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Scipt : MonoBehaviour
{

    // Update is called once per frame
    public float speed;

    void Update() {
        // Get the input from the keyboard.
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        // Move the GameObject based on the input.
        this.transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
    }
}
