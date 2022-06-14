using UnityEngine.Events;
using UnityEngine;

namespace CreateNeptune
{
    public class TapEvent : UnityEvent<TapEventContext>
    {
        public static TapEvent Instance = new TapEvent();
    }

    public struct TapEventContext
    {
        public Vector2 position;
        public RaycastHit[] hits;
    }

}
