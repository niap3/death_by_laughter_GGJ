using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Rigidbody bullet;
    public float speed;
    public Transform targetObject; // Assign the target object in the Inspector
    public float fireInterval = 6f;
    public float deletionVolumeX = 30f;
    public float deletionVolumeYMin = -10f;
    public float deletionVolumeYMax = 10f;
    public float deletionVolumeZMin = -30f;
    public float deletionVolumeZMax = 2f;
    public Animator animator;

    void Start()
    {
        StartCoroutine(FireLoop());
    }

    IEnumerator FireLoop()
    {
        while (true)
        {
            Vector3 shootDirection = (targetObject.position - transform.position).normalized;

            for (int i = 0; i < 3; i++)
            {

                // Calculate rotation based on the total number of bullets and the current iteration
                float angle = i * (60f / 3);
                Quaternion rotation = Quaternion.Euler(0, 0, angle);
                Vector3 rotatedDirection = rotation * shootDirection;

                // Explicitly set the z-component to 0 to restrict movement in the x and y directions
                rotatedDirection.z = 0;

                // Normalize the direction
                rotatedDirection.Normalize();

                // Instantiate the bullet and set its velocity
                var clone = Instantiate(bullet, transform.position, Quaternion.LookRotation(rotatedDirection));

                // Ensure the velocity is strictly along the x and y axes
                clone.velocity = new Vector3(rotatedDirection.x, rotatedDirection.y, 0) * speed;
            }
            yield return new WaitForSeconds(fireInterval);
        }
    }
}
