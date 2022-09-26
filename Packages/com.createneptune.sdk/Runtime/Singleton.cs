using UnityEngine;

namespace CreateNeptune
{
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

        [SerializeField] private bool shouldDestroyOnLoad = false;

        protected void Awake()
        {
            if (this is T self)
            {
                if (Instance == null)
                {
                    Instance = self;

                    if (!shouldDestroyOnLoad)
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

        protected virtual void OnDestroy()
        {
            if (this is T self)
            {
                if (Instance == self)
                {
                    Instance = null;
                }
            }
        }
    }

    //use this when you want to pass on a second type defining the singleton
    public abstract class Singleton<T0, T1> : Singleton<T0>
        where T0 : class
        where T1 : class
    {
    }
}
