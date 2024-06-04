using UnityEngine;

public class HandScript : MonoBehaviour
{
    // The original position of the hand
    private Vector3 originalPosition;

    // The speed at which the hand moves
    public float moveSpeed = 5f;

    // The destination position where the hand moves towards
    private Vector3 destinationPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Save the original position of the hand
        originalPosition = transform.position;

        // Set the initial destination position to the original position
        destinationPosition = originalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the hand towards the destination position
        transform.position = Vector3.MoveTowards(transform.position, destinationPosition, moveSpeed * Time.deltaTime);

        // Check if the hand has reached the destination position
        if (transform.position == destinationPosition)
        {
            // If the hand has reached the destination, set a new destination (original position)
            SetNewDestination();
        }
    }

    // Set a new destination for the hand (original position)
    void SetNewDestination()
    {
        destinationPosition = originalPosition;
    }

    // Move the hand to a specific position (used when the tickle point is touched)
    public void MoveToPosition(Vector3 position)
    {
        destinationPosition = position;
    }

}
