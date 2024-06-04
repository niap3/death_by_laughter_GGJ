using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript1 : MonoBehaviour
{
    public Text LifeText;
    public Life lifeValue;  

    void Start() 
    {
        lifeValue = LifeText.GetComponent<Life>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            lifeValue.life --;
            Debug.Log("hit the target");
        }
    }
}
