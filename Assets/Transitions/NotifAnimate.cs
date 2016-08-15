using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace Assets.Transitions
{
    public class NotifAnimate : MonoBehaviour
    {

        #region Global Variables

        // The image reference of the GUI panel.
        private Image _img;
        // The material reference from the image component
        private Material _mat;
        // The Speed at which the animation moves
        private const float Speed = 5f;
        // The variable in the shader we are manipulating
        private const string C = "_Cutoff";
        // Place holder for _mat.GetFloat(C)
        private float _getFloat;
        // Are we running our animation or not?
        private bool _isRunning;

        #endregion

        // When the Game object is enabled
        private void OnEnable()
        {
            // Run the animation
            _isRunning = true;
            //Set timer for notification
            StartCoroutine("Notification");
        }

        private void Start()
        { 
            // Get the image component for reference
            _img = this.gameObject.GetComponent<Image>();
            // Get the material component for reference
            _mat = _img.material;
            // Set our transparency to hide the notification bar
            SetCutOff(1);
        }

        private void Update()
        {
            // Get the _Cutoff value from the shader.
            _getFloat = _mat.GetFloat(C);

            // When isRunning is triggered and as long as the bar is not 100% visible
            if (_isRunning && _getFloat > 0)
            {
                // Subtract from our _Cutoff to allow animation of the notification
                SetCutOff((_getFloat -= Speed * Time.deltaTime));
            }

            // When the bar is 100% visible
            if (_getFloat <= 0.0f)
            {
                // We are no longer running the animation
                _isRunning = false;
            }
        }

        #region private methods
        //Set the _Cutoff value in the transition shader.
        // @params : floating point number
        //
        private void SetCutOff(float f)
        {
            // Set _Cutoff to value of f
            _mat.SetFloat(C, f);
        }

        // Turn notification off.
        private IEnumerator Notification()
        {
            // Wait for 4 seconds
            yield return new WaitForSeconds(4);
            // Disable the notification canvas
            this.transform.parent.gameObject.SetActive(false);
            // Bar is now hidden
            SetCutOff(1);
        }
    #endregion
    }
}
