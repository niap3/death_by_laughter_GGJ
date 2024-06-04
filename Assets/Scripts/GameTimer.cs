using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 60f; // Adjust the total time as needed
    public float currentTime;
    public Text timerText; // Reference to the UI text element

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        // Debug.Log("Current Time: " + currentTime);
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            GameOver();
        }
        else if (currentTime > 0)
        {
            timerText.text = Mathf.Ceil(currentTime).ToString();
        }
    }

    void GameOver()
    {
        // Implement your game over logic here
        Debug.Log("Game Over");
    }
}
