using System.Collections;
using UnityEngine;

public class GameOverNoise : MonoBehaviour
{
    public AudioClip FBI;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(FBI, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
