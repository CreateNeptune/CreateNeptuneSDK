using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace CreateNeptune
{
    public class InputManager : Singleton<InputManager>
    {
        [Header("Tap Variables")]
        [SerializeField] private float tapThresholdTime = .3f;
        [SerializeField] private LayerMask ignoreRaycastLayermask;
        private float tapTimer;

        [Header("Drag Variables")]
        [SerializeField] private float dragDistanceThreshold = 2f;

        private Vector2 touchStartPosition;
        private Vector2 lastTouchPosition;

        private void Update()
        {
#if UNITY_EDITOR
        UpdateMouseInput();
#else
            UpdateTouchInput();
#endif
        }

        private void UpdateMouseInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                tapTimer = Time.time;
                touchStartPosition = Input.mousePosition;
                lastTouchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                if (Vector2.Distance(Input.mousePosition, touchStartPosition) > dragDistanceThreshold)
                {
                    SendDragEvent(DragState.Dragging, touchStartPosition, Input.mousePosition, lastTouchPosition);
                }

                lastTouchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - tapTimer < tapThresholdTime && !EventSystem.current.IsPointerOverGameObject())
                {
                    SendTapEvent(Input.mousePosition);
                }
                else if (Vector2.Distance(Input.mousePosition, touchStartPosition) > dragDistanceThreshold)
                {
                    SendDragEvent(DragState.Ended, touchStartPosition, Input.mousePosition, lastTouchPosition);
                }
            }
        }

        private void UpdateTouchInput()
        {
            if (Input.touchCount > 0)
            {
                switch (Input.touches[0].phase)
                {
                    case TouchPhase.Began:
                        {
                            tapTimer = Time.time;
                            touchStartPosition = Input.touches[0].position;
                            lastTouchPosition = Input.touches[0].position;
                            break;
                        }
                    case TouchPhase.Moved:
                        {
                            if (Vector2.Distance(Input.touches[0].position, touchStartPosition) > dragDistanceThreshold)
                            {
                                SendDragEvent(DragState.Dragging, touchStartPosition, Input.touches[0].position, lastTouchPosition);
                            }

                            lastTouchPosition = Input.touches[0].position;

                            break;
                        }
                    case TouchPhase.Stationary:
                        {
                            if (Vector2.Distance(Input.touches[0].position, touchStartPosition) > dragDistanceThreshold)
                            {
                                SendDragEvent(DragState.Dragging, touchStartPosition, Input.touches[0].position, lastTouchPosition);
                            }

                            lastTouchPosition = Input.touches[0].position;

                            break;
                        }
                    case TouchPhase.Ended:
                        {
                            if (Time.time - tapTimer < tapThresholdTime && !EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
                            {
                                SendTapEvent(Input.touches[0].position);
                            }
                            else if (Vector2.Distance(Input.touches[0].position, touchStartPosition) > dragDistanceThreshold)
                            {
                                SendDragEvent(DragState.Ended, touchStartPosition, Input.touches[0].position, lastTouchPosition);
                            }

                            break;
                        }
                    case TouchPhase.Canceled:
                        {
                            break;
                        }
                }
            }
        }

        private void SendTapEvent(Vector2 screenPosition)
        {
            RaycastHit[] hits = Physics.RaycastAll(Camera.main.ScreenPointToRay(screenPosition), Mathf.Infinity, ignoreRaycastLayermask);
            TapEvent.Instance.Invoke(new TapEventContext
            {
                position = screenPosition,
                hits = hits
            });
        }

        private void SendDragEvent(DragState state, Vector2 startScreenPostion, Vector2 endScreenPosition, Vector2 lastEndPosition)
        {
            DragEvent.Instance.Invoke(new DragEventContext
            {
                state = state,
                startPosition = startScreenPostion,
                endPosition = endScreenPosition,
                dragDistance = Vector2.Distance(startScreenPostion, endScreenPosition),
                deltaDragDistance = Vector2.Distance(lastEndPosition, endScreenPosition)
            });
        }
    }

    public class TapEvent : UnityEvent<TapEventContext>
    {
        public static TapEvent Instance = new TapEvent();
    }

    public struct TapEventContext
    {
        public Vector2 position;
        public RaycastHit[] hits;
    }

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