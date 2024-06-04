using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BulletCollision : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5f || transform.position.x < -30f || transform.position.x > 30f)
        {
            Destroy(gameObject);
        }
    }
}

