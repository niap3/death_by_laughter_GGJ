using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingFeather : MonoBehaviour
{
    public float fallSpeed = 1.0f;
    public float rotationSpeed = 50.0f;

    void Start()
    {
        // Set initial rotation to give it a feather-like appearance
        transform.rotation = Quaternion.Euler(Random.Range(-10f, 10f), Random.Range(-10f, 10f), Random.Range(-30f, 30f));
    }

    void Update()
    {
        // Fall down
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);

        // Rotate the feather for a natural falling motion
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Destroy(gameObject);
        }

        // Optionally, destroy the feather when it's out of the screen
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }
}




