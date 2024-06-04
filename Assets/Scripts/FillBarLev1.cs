using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;


public class FillBarLev1 : MonoBehaviour
{
    public String SceneName;
    public Image healthBar;
    public float healthAmount;
    public TotTickles totTickles;
    public Animator ChandelierFall;
    public Animator CharcaterFall;
    public AudioClip fall;
    private bool hasFallen = false;

    void Start()
    {
        totTickles = GameObject.Find("TotTick").GetComponent<TotTickles>();
    }

    void Update()
    {
        healthAmount = totTickles.TickleScore;

        healthBar.fillAmount = healthAmount / 100f;

        if (healthBar.fillAmount == 1 && !hasFallen)
        {
            AudioSource.PlayClipAtPoint(fall,transform.position);
            // Play the "fall" animation using the Animation component
            ChandelierFall.Play("fallag");
            CharcaterFall.Play("Falling");
            CharcaterFall.Play("Fallen");

            StartCoroutine(LoadScene(4f));

            // Set the flag to true to prevent further triggers
            hasFallen = true;
        }
    }

    IEnumerator LoadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneName);
    }
}
