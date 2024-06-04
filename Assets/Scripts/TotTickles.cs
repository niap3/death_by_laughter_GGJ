using UnityEngine;
using UnityEngine.UIElements;

public class TotTickles : MonoBehaviour
{
    public float ClickedPoints;
    public float TickleScore;
    public float TotalPoints = 30;
    public static TotTickles Instance;

    void Start()
    {
       if(Instance == null)
       {
            Instance = this;
       }
       else
       {
            Destroy(this);
       }
    }
}
