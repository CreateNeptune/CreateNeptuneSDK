using UnityEngine;

namespace CreateNeptune { 
    /// <summary>
    /// <para>Base class for singletons.</para>
    /// <para>
    /// OnSuccessfulAwake can be implemented and is called when the
    /// first instance of this singleton is set.
    /// </para>
    /// <para>Example of declaring a child of this is included in the source code comments</para>
    /// </summary>
    /// <typeparam name="T">Always set this to the child type</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : class
    {
        /*
        private class Example : Singleton<Example>
        {
            protected override void OnSuccessfulAwake()
            {
                Debug.Log("Started example singleton.");
            }
        }
        */

        public static T Instance;

        private void Awake()
        {
            if (this is T self)
            {
                if (Instance == null)
                {
                    Instance = self;
                    DontDestroyOnLoad(gameObject);
                    OnSuccessfulAwake();
                }
                else if (Instance != self)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("You did not set an appropriate type for this singleton. See examples for details.");
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// This is called when just and only after the instance of the singleton is set.
        /// Override this to implement functionality to occur at that moment.
        /// </summary>
        protected virtual void OnSuccessfulAwake()
        {

        }
    }
}
