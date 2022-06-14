using UnityEngine.Events;
using UnityEngine;

namespace CreateNeptune
{
    public class DragEvent : UnityEvent<DragEventContext>
    {
        public static DragEvent Instance = new DragEvent();
    }

    public enum DragState
    {
        Dragging, Ended
    }

    public struct DragEventContext
    {
        public DragState state;
        public Vector2 startPosition;
        public Vector2 endPosition;
        public float dragDistance;
        public float deltaDragDistance;
    }
}
