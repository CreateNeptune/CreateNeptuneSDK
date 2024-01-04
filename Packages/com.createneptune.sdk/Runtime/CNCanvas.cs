using UnityEngine;
using UnityEngine.Events;
namespace CreateNeptune
{
    public class CNCanvas : MonoBehaviour
    {
        // TODO: I would recommend we add additional transitions other than
        // fade. In particular, slide (in various directions) as well as scale.
        [SerializeField] protected Canvas canvas;
        [SerializeField] protected float timeToFade = 0.25f;

        //you must assign this in Awake() on the child class
        protected UnityEvent ToggleEvent;

        protected virtual void OnEnable()
        {
            ToggleEvent?.AddListener(OnToggle);
            if (ToggleEvent == null)
            {
                Debug.LogError("NO ToggleEvent assigned to instance of " + this.name + " !");
            }
        }

        protected virtual void OnDisable()
        {
            ToggleEvent?.RemoveListener(OnToggle);
        }

        private void OnToggle()
        {
            Toggle(!canvas.enabled);
        }

        protected void Toggle(bool isOn)
        {
            if (isOn)
            {
                StartCoroutine(CNAction.FadeObject(canvas, timeToFade, 0, 1, true, false, false));
            }
            else
            {
                StartCoroutine(CNAction.FadeObject(canvas, timeToFade, 1, 0, false, true, false));
            }

            PostToggle(isOn);
        }

        protected virtual void PostToggle(bool isOn)
        {

        }
    }
}
