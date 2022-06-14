using UnityEngine;
using UnityEngine.Events;
namespace CreateNeptune
{

    public class CNCanvas : MonoBehaviour
    {
        [SerializeField] protected Canvas canvas;
        [SerializeField] private float timeToFade = .25f;

        //you must assign this in Awake() on the child class
        protected UnityEvent ToggleEvent;

        protected void OnEnable()
        {
            ToggleEvent?.AddListener(OnToggle);
            if (ToggleEvent == null)
            {
                Debug.LogError("NO ToggleEvent assigned to instance of " + this.name + " !");
            }
        }

        protected void OnDisable()
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
                StartCoroutine(MPAction.FadeObject(canvas, timeToFade, 0, 1, true, false, false));
            }
            else
            {
                StartCoroutine(MPAction.FadeObject(canvas, timeToFade, 1, 0, false, true, false));
            }
            PostToggle(isOn);
        }

        protected virtual void PostToggle(bool isOn)
        {

        }
    }
}