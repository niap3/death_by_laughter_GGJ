using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPushup : MonoBehaviour
{
    // Start is called before the first frame update
    public float fallSpeed = 1.0f;

    public float rotationSpeed = 50.0f;

    NewBehaviourScript newBehaviourScript;

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
        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
        //     newBehaviourScript.Anim();
        //     Destroy(gameObject);
        // }

        // Optionally, destroy the feather when it's out of the screen
        if (transform.position.y < -5f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Target"))
        {
            newBehaviourScript.Anim();
            Destroy(gameObject);
        }
    }
}
