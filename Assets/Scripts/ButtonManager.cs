using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button pushUpButton;
    // public Button featherButton;
    public Animator animator;
    public AudioClip push;
    public GameObject TicklePoint;
    // public Vector3 TicklePosition;
    public TotTickles totTickles;

    public GameObject ticklepoint;
    public 
    void Start()
    {

        pushUpButton.gameObject.SetActive(false);
        // featherButton.gameObject.SetActive(false);

        StartCoroutine(ShowButtonAfterDelay(pushUpButton, 5f));
        // StartCoroutine(ShowButtonAfterDelay(featherButton, 10f));
        totTickles = GameObject.Find("TotTick").GetComponent<TotTickles>();
    }

    IEnumerator ShowButtonAfterDelay(Button button, float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Show the button
        button.gameObject.SetActive(true);
    }

    public void OnPushUpButtonClick()
    {   
        AudioSource.PlayClipAtPoint(push,transform.position);
        
        animator.SetTrigger("PushUpTrigge");
        totTickles.TickleScore = totTickles.TickleScore + 20f;

        pushUpButton.gameObject.SetActive(false);
    }

    // public void OnFeatherButtonClick(Button button)
    // {
    //     button.gameObject.SetActive(false);
    // }
}
