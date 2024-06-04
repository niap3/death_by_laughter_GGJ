// using System.Collections;
// using UnityEngine;

// public class TickleScript : MonoBehaviour
// {
//     public int tickles = 5;
//     public HandScript hand;
//     public TotTickles totTickles;

//     // Blinking parameters
//     public float blinkDuration = 0.5f;

//     void Start()
//     {
//         totTickles = GameObject.Find("TotTick").GetComponent<TotTickles>();
//     }

//     void Update()
//     {
//         // Check if there is at least one touch
//         if (Input.touchCount > 0)
//         {
//             // Get the first touch
//             Touch touch = Input.GetTouch(0);

//             // Check if the touch phase is "Began" (user started touching the screen)
//             if (touch.phase == TouchPhase.Began)
//             {
//                 // Check if the touch position is over this object
//                 Ray ray = Camera.main.ScreenPointToRay(touch.position);
//                 RaycastHit hit;

//                 if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
//                 {
//                     // Check if there are remaining tickles for this object
//                     if (tickles > 0)
//                     {
//                         totTickles.ClickedPoints = totTickles.ClickedPoints + 5f;

//                         Debug.LogError("TP " + totTickles.ClickedPoints);
//                         TotTickles.instance.ticklescore++;

//                         tickles--;

//                         // Move the hand towards this tickle point
//                         hand.MoveToPosition(transform.position);

//                         // Check if tickles reached the limit after the reduction
//                         if (tickles == 0)
//                         {
//                             // Destroy this tickle point
//                             Destroy(gameObject);
//                         }
//                     }
//                 }
//             }
//         }
//     }
// }
