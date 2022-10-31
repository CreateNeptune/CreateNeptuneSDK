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
        [SerializeField] private float tapThresholdTime = 0.3f;
        [SerializeField] private LayerMask ignoreRaycastLayermask;
        private float tapTimer;
        // isPointerOverGameObject always returns false on touches ended, so check this on initial tap to determine if
        // touch was over a GameObject.
        bool wasPointerOverGameObject;

        [Header("Drag Variables")]
        [SerializeField] private float dragDistanceThreshold = 2f;
        // For common input calculation, it's better to use distance squared:
        // https://docs.unity3d.com/ScriptReference/Vector3-sqrMagnitude.html
        private float dragDistanceThresholdSqr;

        private Vector2 touchStartPosition;
        private Vector2 lastTouchPosition;

        private bool dragging = false;

        protected override void OnSuccessfulAwake()
        {
            dragDistanceThresholdSqr = dragDistanceThreshold * dragDistanceThreshold;
        }

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
                if (((Vector2)Input.mousePosition - touchStartPosition).sqrMagnitude > dragDistanceThresholdSqr)
                {
                    SendDragEvent(DragState.Dragging, touchStartPosition, Input.mousePosition, lastTouchPosition);
                    dragging = true;
                }
                else if(dragging)
                {
                    SendDragEvent(DragState.Ended, touchStartPosition, Input.mousePosition, lastTouchPosition);
                    dragging = false;
                }

                lastTouchPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (Time.time - tapTimer < tapThresholdTime &&
                    (EventSystem.current == null || !EventSystem.current.IsPointerOverGameObject()))
                {
                    SendTapEvent(Input.mousePosition);
                }
                if (dragging || ((Vector2)Input.mousePosition - touchStartPosition).sqrMagnitude > dragDistanceThresholdSqr)
                {
                    SendDragEvent(DragState.Ended, touchStartPosition, Input.mousePosition, lastTouchPosition);
                    dragging = false;
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
                        tapTimer = Time.time;
                        touchStartPosition = Input.touches[0].position;
                        lastTouchPosition = Input.touches[0].position;
                        wasPointerOverGameObject = EventSystem.current != null && EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId);

                        break;
                    case TouchPhase.Moved:
                        if (dragging || (Input.touches[0].position - touchStartPosition).sqrMagnitude > dragDistanceThresholdSqr)
                        {
                            SendDragEvent(DragState.Dragging, touchStartPosition, Input.touches[0].position, lastTouchPosition);
                            dragging = true;
                        }
                        else if (dragging)
                        {
                            SendDragEvent(DragState.Ended, touchStartPosition, Input.mousePosition, lastTouchPosition);
                            dragging = false;
                        }

                        lastTouchPosition = Input.touches[0].position;

                        break;
                    case TouchPhase.Stationary:
                        if (dragging || (Input.touches[0].position - touchStartPosition).sqrMagnitude > dragDistanceThresholdSqr)
                        {
                            SendDragEvent(DragState.Dragging, touchStartPosition, Input.touches[0].position, lastTouchPosition);
                            dragging = true;
                        }

                        lastTouchPosition = Input.touches[0].position;

                        break;
                    case TouchPhase.Ended:
                        if (Time.time - tapTimer < tapThresholdTime && !wasPointerOverGameObject)
                        {
                            SendTapEvent(Input.touches[0].position);
                        }
                        if (dragging || (Input.touches[0].position - touchStartPosition).sqrMagnitude > dragDistanceThresholdSqr)
                        {
                            SendDragEvent(DragState.Ended, touchStartPosition, Input.touches[0].position, lastTouchPosition);
                            dragging = false;
                        }

                        break;
                    case TouchPhase.Canceled:
                        break;
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

        private void SendDragEvent(DragState state, Vector2 startScreenPosition, Vector2 endScreenPosition, Vector2 lastEndPosition)
        {
            DragEvent.Instance.Invoke(new DragEventContext
            {
                state = state,
                startPosition = startScreenPosition,
                endPosition = endScreenPosition,
                dragDistance = Vector2.Distance(startScreenPosition, endScreenPosition),
                deltaDragDistance = Vector2.Distance(lastEndPosition, endScreenPosition)
            });
        }
    }
}