using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class featherspawn : MonoBehaviour
{
    public GameObject featherPrefab; // Reference to the feather prefab
    public GameObject pushUpPrefab; // Reference to the feather prefab
    public Vector3 startPoint= new Vector3(5f, 13f, -28f);
    public Vector3 endPoint= new Vector3(-4f, 13f, -28f);

    void Start() 
    {
        StartCoroutine(SpawnFeatherAfterDelay(5f));
        StartCoroutine(SpawnPushUpAfterDelay(10f));
    }

    IEnumerator SpawnFeatherAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnFeather();
    }

    IEnumerator SpawnPushUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnPushUp();
    }

    void SpawnFeather()
    {
        if (featherPrefab != null)
        {
            // Get a random x value within the range of the two points
            float randomX = Random.Range(Mathf.Min(startPoint.x, endPoint.x), Mathf.Max(startPoint.x, endPoint.x));

            // Set the position with the random x and the y and z values from the start point
            Vector3 randomPosition = new Vector3(randomX, startPoint.y, startPoint.z);

            // Instantiate the feather at the random position
            GameObject featherInstance = Instantiate(featherPrefab, randomPosition, Quaternion.identity);

            // Attach the FallingFeather script to the instantiated feather (if not already attached)
            FallingFeather fallingFeather = featherInstance.GetComponent<FallingFeather>();

            if (fallingFeather == null)
            {
                fallingFeather = featherInstance.AddComponent<FallingFeather>();
            }
        }
        else
        {
            Debug.LogError("Feather prefab not assigned to the FeatherSpawner script!");
        }
    }

    void SpawnPushUp()
    {
        if (pushUpPrefab != null)
        {
            // Get a random x value within the range of the two points
            float randomX = Random.Range(Mathf.Min(startPoint.x, endPoint.x), Mathf.Max(startPoint.x, endPoint.x));

            // Set the position with the random x and the y and z values from the start point
            Vector3 randomPosition = new Vector3(randomX, startPoint.y, startPoint.z);

            // Instantiate the feather at the random position
            GameObject pushupInstance = Instantiate(pushUpPrefab, randomPosition, Quaternion.identity);

            // Attach the FallingPushup script to the instantiated feather (if not already attached)
            FallingPushup FallingPushup = pushupInstance.GetComponent<FallingPushup>();

            if (FallingPushup == null)
            {
                FallingPushup = pushupInstance.AddComponent<FallingPushup>();
            }

        }
        else
        {
            Debug.LogError("Pushup prefab not assigned to the FeatherSpawner script!");   
        }
    }
}

    


