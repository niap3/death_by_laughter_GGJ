using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public int life = 5;
    public Text LifeText;

    // Start is called before the first frame update
    void Start()
    {
        life = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (life >= 0)
        {
            LifeText.text = life.ToString() + "/5";
        }
        else
        {
            Debug.Log("game over because life");
        }
    }
}
