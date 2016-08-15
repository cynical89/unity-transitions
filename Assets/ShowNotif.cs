using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Assets.Transitions;

namespace Assets
{
    public class ShowNotif : MonoBehaviour
    {
        // Get the notification object
        public GameObject Notification;

        private void Update()
        {
            /* This is a testing solution. This will enable the notification canvas, 
             * and run the animation when it gets enabled. This gives reference to 
             * enabling the notification on system specific events.
             *
            */

            // Press F10 key
            if (Input.GetKeyDown(KeyCode.F10))
            { 
                // Enable Notification
                Notification.SetActive(true);
            }
        }
    }
}
