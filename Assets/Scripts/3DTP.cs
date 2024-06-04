using UnityEngine;
using System.Collections;

public class TickleAndBlink : MonoBehaviour
{
    public int tickles = 5;
    public HandScript hand;
    public Material mat;
    public Color targetColor = Color.red;
    public float blinkDuration = 1.0f;
    public float highOpacity = 0.8f;
    public float lowOpacity = 0.2f;
    public GameObject TicklePoint;
    // public Vector3 TicklePosition;
    public TotTickles totTickles;
    private float startTime;
    // private bool hasFallen = false;
    public Animator yourAnimator;
    public AudioClip roar;
    public AudioClip laugh;
    public AudioClip Tickle;
    void Start()
    {
        AudioSource.PlayClipAtPoint(roar,transform.position);
        startTime = Time.time;
        // TicklePoint.transform.position = TicklePosition;
        totTickles = GameObject.Find("TotTick").GetComponent<TotTickles>();

    }

    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            // Get the first touch
            Touch touch = Input.GetTouch(0);

            // Check if the touch phase is "Began" (user started touching the screen)
            if (touch.phase == TouchPhase.Began)
            {
                // Check if the touch position is over this object
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
                {
                    // Check if there are remaining tickles for this object
                    if (tickles > 0)
                    {
                        totTickles.TickleScore = totTickles.TickleScore + 5f;
                        TotTickles.Instance.ClickedPoints ++;
                        AudioSource.PlayClipAtPoint(laugh,transform.position);
                        AudioSource.PlayClipAtPoint(Tickle,transform.position);
                        StartCoroutine(PlayAnimationAfterDelay("Laughing", 3f));
                        tickles --;

                        // if (!hasFallen)
                        // {
                            
                        //     hasFallen = true;
                        // }

                        // Move the hand towards this tickle point
                        hand.MoveToPosition(transform.position);

                        // Check if tickles reached the limit after the reduction
                        if (tickles == 0)
                        {
                            // Destroy this tickle point
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    IEnumerator PlayAnimationAfterDelay(string animationName, float delay)
    {
        yourAnimator.Play(animationName);
        yield return new WaitForSeconds(delay);
    }

        // Calculate the time elapsed since the script started
        float elapsedTime = Time.time - startTime;

        // Calculate the blink strength based on time
        float blinkStrength = Mathf.PingPong(elapsedTime / blinkDuration, 1.0f);

        // Set the color and opacity in the material
        Color currentColor = targetColor;

        // Oscillate between high and low opacity
        currentColor.a = Mathf.Lerp(lowOpacity, highOpacity, blinkStrength);

        mat.color = currentColor;
    }
}
