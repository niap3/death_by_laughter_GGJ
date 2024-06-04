using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameLoader : MonoBehaviour
{
   public Animator animator;

    private int GameToLoad;
    public AudioClip FBI;

    // Update is called once per frame

    void Start()
    {
        AudioSource.PlayClipAtPoint(FBI, transform.position);
        //animator.SetTrigger("Button");
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            FadeToGame(1);
        }
    }
    public void FadeToGame(int SceneIndex)
    {
        GameToLoad = SceneIndex;
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(GameToLoad);
    }
}
