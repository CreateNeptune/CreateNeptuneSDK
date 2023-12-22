// Create Neptune SDK (c) 2021 Create Neptune LLC.
// All rights reserved.

namespace CreateNeptune
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public static class MPAction
    {
        public enum EaseType
        {
            // Deprecated
            easein,
            easeout, 
            easeineaseout, 
            linear, 
            elasticeaseout,

            // Use these
            Linear,
            InSine,
            OutSine,
            InOutSine,
            InQuad,
            OutQuad,
            InOutQuad,
            InCubic,
            OutCubic,
            InOutCubic,
            InQuart,
            OutQuart,
            InOutQuart,
            InQuint,
            OutQuint,
            InOutQuint,
            InExpo,
            OutExpo,
            InOutExpo,
            InCirc,
            OutCirc,
            InOutCirc,
            InBack,
            OutBack,
            InOutBack,
            InElastic,
            OutElastic,
            InOutElastic,
            InBounce,
            OutBounce,
            InOutBounce
        }

        private static readonly Dictionary<EaseType, EasingFunc> easingFuncDictionary = new()
        {
            // Support for deprecated enum names
            { EaseType.easein, EaseInSine },
            { EaseType.easeout, EaseOutSine },
            { EaseType.easeineaseout, EaseInOutOld },
            { EaseType.linear, EaseLinear },
            { EaseType.elasticeaseout, EaseOutElastic },

            // New naming scheme
            { EaseType.Linear, EaseLinear },
            { EaseType.InSine, EaseInSine },
            { EaseType.OutSine, EaseOutSine },
            { EaseType.InOutSine, EaseInOutSine },
            { EaseType.InQuad, EaseInQuad },
            { EaseType.OutQuad, EaseOutQuad },
            { EaseType.InOutQuad, EaseInOutQuad },
            { EaseType.InCubic, EaseInCubic },
            { EaseType.OutCubic, EaseOutCubic },
            { EaseType.InOutCubic, EaseInOutCubic },
            { EaseType.InQuart, EaseInQuart },
            { EaseType.OutQuart, EaseOutQuart },
            { EaseType.InOutQuart, EaseInOutQuart },
            { EaseType.InQuint, EaseInQuint },
            { EaseType.OutQuint, EaseOutQuint },
            { EaseType.InOutQuint, EaseInOutQuint },
            { EaseType.InExpo, EaseInExpo },
            { EaseType.OutExpo, EaseOutExpo },
            { EaseType.InOutExpo, EaseInOutExpo },
            { EaseType.InCirc, EaseInCirc },
            { EaseType.OutCirc, EaseOutCirc },
            { EaseType.InOutCirc, EaseInOutCirc },
            { EaseType.InBack, EaseInBack },
            { EaseType.OutBack, EaseOutBack },
            { EaseType.InOutBack, EaseInOutBack },
            { EaseType.InElastic, EaseInElastic },
            { EaseType.OutElastic, EaseOutElastic },
            { EaseType.InOutElastic, EaseInOutElastic },
            { EaseType.InBounce, EaseInBounce },
            { EaseType.OutBounce, EaseOutBounce },
            { EaseType.InOutBounce, EaseInOutBounce },
        };

        public delegate float EasingFunc(float x);

        /// <summary>
        /// This function is a quick way to get an easing function using the EaseType enum <br></br>
        /// </summary>
        /// <param name="type">Easing function to use</param>
        /// <param name="t">normalized time value (from 0 to 1)</param>
        /// <returns></returns>
        public static float GetEasedTime(EaseType type, float t)
        {
            return easingFuncDictionary[type](t);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, bool local, float animationTime, Vector3 startRotation,
            Vector3 endRotation, EaseType easeType, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            // Cache transform
            Transform rotateObjectT = rotateObject.transform;

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                easedTime = GetEasedTime(easeType, counter / animationTime);

                if (local)
                    rotateObjectT.localRotation = Quaternion.Lerp(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), easedTime);
                else
                    rotateObjectT.rotation = Quaternion.Lerp(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), easedTime);

                yield return null;
            }

            // guarantee final rotation
            if (local)
                rotateObjectT.localRotation = Quaternion.Euler(endRotation);
            else
                rotateObjectT.rotation = Quaternion.Euler(endRotation);
        }

#region RotateObject overloads
        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, EaseType.OutSine, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation, EaseType easeType)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, easeType, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation, EaseType easeType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, easeType, timeUnscaled);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, EaseType.OutSine, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, EaseType easeType)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, easeType, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, EaseType easeType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, easeType, timeUnscaled);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, EaseType.OutSine, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation, EaseType easeType)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, easeType, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation, EaseType easeType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, easeType, timeUnscaled);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, EaseType.OutSine, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, EaseType easeType)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, easeType, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, EaseType easeType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, easeType, timeUnscaled);
        }
#endregion

        public static IEnumerator MoveObject(GameObject moveObject, bool localPosition, float animationTime, Vector3 startPosition, Vector3 endPosition,
            EaseType easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            // Cache transform
            Transform moveObjectT = moveObject.transform;

            if (activateAtStart)
            {
                moveObject.SetActive(true);
            }

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                easedTime = GetEasedTime(easeType, counter / animationTime);

                if (localPosition)
                {
                    moveObjectT.localPosition = Vector3.LerpUnclamped(startPosition, endPosition, easedTime);
                }
                else
                {
                    moveObjectT.position = Vector3.LerpUnclamped(startPosition, endPosition, easedTime);
                }

                yield return null;
            }

            // guarantee endPosition
            if (localPosition)
            {
                moveObjectT.localPosition = endPosition;
            }
            else
            {
                moveObjectT.position = endPosition;
            }

            if (deactivateAtEnd)
            {
                moveObject.SetActive(false);
            }
        }

#region MoveObject overloads
        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition, EaseType easeType)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, easeType, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition, EaseType easeType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, easeType, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, EaseType easeType)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, easeType, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, EaseType easeType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, easeType, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.localPosition, endPosition, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition, EaseType easeType)
        {
            yield return MoveObject(moveObject, true, animationTime, moveObject.transform.localPosition, endPosition, easeType, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition, EaseType easeType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, true, animationTime, moveObject.transform.localPosition, endPosition, easeType, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, EaseType easeType)
        {
            yield return MoveObject(moveObject, true, animationTime, startPosition, endPosition, easeType, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, EaseType easeType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, true, animationTime, startPosition, endPosition, easeType, false, false, timeUnscaled);
        }
#endregion

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition,
            EaseType easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            // Cache transform
            RectTransform moveObjectT = moveObject.GetComponent<RectTransform>();

            if (activateAtStart)
            {
                moveObject.SetActive(true);
            }

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                easedTime = GetEasedTime(easeType, counter / animationTime);

                moveObjectT.anchoredPosition = Vector2.LerpUnclamped(startPosition, endPosition, easedTime);

                yield return null;
            }

            // guarantee endPosition
            moveObjectT.anchoredPosition = endPosition;

            if (deactivateAtEnd)
            {
                moveObject.SetActive(false);
            }
        }

#region MoveCanvasObject overloads
        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition, EaseType easeType)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, easeType, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition, EaseType easeType, bool timeUnscaled)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, easeType, false, false, timeUnscaled);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition, EaseType easeType)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, easeType, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition, EaseType easeType, bool timeUnscaled)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, easeType, false, false, timeUnscaled);
        }
#endregion

        /// ***WARNING: THIS CAUSES PERFORMANCE ISSUES ON ANDROID DEVICES IF USED EXCESSIVELY OR ON LARGE OR TRANSPARENT OBJECTS. BEWARE!***
        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale,
            EaseType easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            // Cache transform
            RectTransform scaleObjectT = scaleObject.GetComponent<RectTransform>();

            if (activateAtStart)
                scaleObject.SetActive(true);

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                    counter += Time.unscaledDeltaTime;
                else
                    counter += Time.deltaTime;

                easedTime = GetEasedTime(easeType, counter / animationTime);

                if (scaleObjectT != null)
                    scaleObjectT.localScale = Vector3.LerpUnclamped(startScale, endScale, easedTime);

                yield return null;
            }

            // guarantee endScale
            if (scaleObjectT != null)
                scaleObjectT.localScale = endScale;

            if (deactivateAtEnd)
                scaleObject.SetActive(false);
        }

#region ScaleCanvasObject overloads
        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale, EaseType easeType)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, easeType, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale, EaseType easeType, bool timeUnscaled)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, easeType, false, false, timeUnscaled);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale, EaseType easeType)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, easeType, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale, EaseType easeType, bool timeUnscaled)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, easeType, false, false, timeUnscaled);
        }
#endregion

        public static IEnumerator FadeObject(GameObject objectToFade, float timeToFade, float startAlpha, float endAlpha, bool activateAtStart,
            bool deactivateAtEnd, bool timeUnscaled, EaseType easeType)
        {
            float counter = 0f;

            if (activateAtStart)
            {
                objectToFade.SetActive(true);
            }

            System.Action<float> setter;

            if (objectToFade.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer objectToFadeSpriteRenderer = objectToFade.GetComponent<SpriteRenderer>();
                setter = (x) => 
                {
                    Color newColor = objectToFadeSpriteRenderer.color;
                    newColor.a = x;
                    objectToFadeSpriteRenderer.color = newColor;
                };
            }
            else if (objectToFade.GetComponent<CanvasGroup>() != null)
            {
                CanvasGroup objectToFadeImage = objectToFade.GetComponent<CanvasGroup>();
                setter = (x) => objectToFadeImage.alpha = x;
            }
            else if (objectToFade.GetComponent<Image>() != null)
            {
                Image objectToFadeImage = objectToFade.GetComponent<Image>();
                setter = (x) => 
                {
                    Color newColor = objectToFadeImage.color;
                    newColor.a = x;
                    objectToFadeImage.color = newColor;
                };
            }
            else if (objectToFade.GetComponent<Text>() != null)
            {
                Text objectToFadeImage = objectToFade.GetComponent<Text>();
                setter = (x) => 
                {
                    Color newColor = objectToFadeImage.color;
                    newColor.a = x;
                    objectToFadeImage.color = newColor;
                };
            }

            else if (objectToFade.GetComponent<RawImage>() != null)
            {
                RawImage objectToFadeImage = objectToFade.GetComponent<RawImage>();
                setter = (x) => 
                {
                    Color newColor = objectToFadeImage.color;
                    newColor.a = x;
                    objectToFadeImage.color = newColor;
                };
            }
            else
            {
                yield break;
            }

            while (counter <= timeToFade)
            {
                setter(startAlpha + (endAlpha - startAlpha) * GetEasedTime(easeType, counter / timeToFade));

                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                yield return null;
            }

            // guarantee end alpha
            setter(endAlpha);

            if (deactivateAtEnd)
            {
                objectToFade.SetActive(false);
            }
        }

#region FadeObject overloads
        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, false, false, false, EaseType.Linear);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float endAlpha) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade.gameObject), endAlpha, false, false, false, EaseType.Linear);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, false, false, false, EaseType.Linear);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float startAlpha, float endAlpha) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, false, false, false, EaseType.Linear);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, false, false, false, easeType);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float endAlpha, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade.gameObject), endAlpha, false, false, false, easeType);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, false, false, false, easeType);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float startAlpha, float endAlpha, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, false, false, false, easeType);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha, bool timeUnscaled, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float endAlpha, bool timeUnscaled, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade.gameObject), endAlpha, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, bool timeUnscaled, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float startAlpha, float endAlpha, bool timeUnscaled, EaseType easeType) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, activateAtStart, deactivateAtEnd, timeUnscaled, EaseType.Linear);
        }

        public static IEnumerator FadeObject(Behaviour objectToFade, float timeTofade, float startAlpha, float endAlpha, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, activateAtStart, deactivateAtEnd, timeUnscaled, EaseType.Linear);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeToFade, float startAlpha, float endAlpha, bool activateAtStart,
           bool deactivateAtEnd, bool timeUnscaled, EaseType easeType)
        {
            if (activateAtStart)
            {
                behaviorToFade.enabled = true;
            }

            yield return FadeObject(behaviorToFade.gameObject, timeToFade, startAlpha, endAlpha, false, false, timeUnscaled, easeType);

            if (deactivateAtEnd)
            {
                behaviorToFade.enabled = false;
            }
        }
#endregion

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, bool activateAtStart,
            bool deactivateAtEnd, bool timeUnscaled, EaseType easeType)
        {
            float counter = 0f;

            if (activateAtStart)
            {
                objectToColor.SetActive(true);
            }

            System.Action<Color> setter;

            if (objectToColor.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer objectToColorSpriteRenderer = objectToColor.GetComponent<SpriteRenderer>();
                setter = (x) => objectToColorSpriteRenderer.color = x;
            }
            else if (objectToColor.GetComponent<Image>() != null)
            {
                Image objectToColorImage = objectToColor.GetComponent<Image>();
                setter = (x) => objectToColorImage.color = x;
            }
            else if (objectToColor.GetComponent<MeshRenderer>() != null)
            {
                MeshRenderer objectToColorRenderer = objectToColor.GetComponent<MeshRenderer>();
                setter = (x) => objectToColorRenderer.material.color = x;
            }
            else if (objectToColor.GetComponent<SkinnedMeshRenderer>() != null)
            {
                SkinnedMeshRenderer objectToColorRenderer = objectToColor.GetComponent<SkinnedMeshRenderer>();
                setter = (x) => objectToColorRenderer.material.color = x;
            }
            else if (objectToColor.GetComponent<TextMeshProUGUI>() != null)
            {
                TextMeshProUGUI textToColor = objectToColor.GetComponent<TextMeshProUGUI>();
                setter = (x) => textToColor.color = x;
            }
            else
            {
                yield break;
            }

            while (counter <= timeToFade)
            {
                setter(startColor + (endColor - startColor) * GetEasedTime(easeType, counter / timeToFade));

                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                yield return null;
            }

            // guarantee end alpha
            setter(endColor);

            if (deactivateAtEnd)
            {
                objectToColor.SetActive(false);
            }
        }

#region ColorObject overloads        
        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, false, false, false, EaseType.linear);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, false, false, false, EaseType.linear);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor, EaseType easeType)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, false, false, false, easeType);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, EaseType easeType)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, false, false, false, easeType);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor, bool timeUnscaled, EaseType easeType)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, bool timeUnscaled, EaseType easeType)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, false, false, timeUnscaled, easeType);
        }
#endregion
        
        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval,
            float totalTime, Color startColor, Color endColor, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled, EaseType easeType)
        {
            int numFlashes = (int)(totalTime / flashInterval);

            if (activateAtStart)
            {
                objectToFlash.SetActive(true);
            }

            for (int i = 0; i < numFlashes; i++)
            {
                yield return ColorObject(objectToFlash, flashInterval, startColor, endColor, false, false, timeUnscaled, easeType);

                yield return ColorObject(objectToFlash, flashInterval, endColor, startColor, false, false, timeUnscaled, easeType);
            }

            if (deactivateAtEnd)
            {
                objectToFlash.SetActive(false);
            }
        }

#region FlashAnimation overloads
        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, false,
                false, false, EaseType.InOutSine);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, false,
                false, false, EaseType.InOutSine);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor, EaseType easeType)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, false,
                false, false, easeType);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor, EaseType easeType)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, false,
                false, false, easeType);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor,
            bool timeUnscaled, EaseType easeType)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, false,
                false, timeUnscaled, easeType);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor,
            bool timeUnscaled, EaseType easeType)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, false,
                false, timeUnscaled, easeType);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor,
            Color endColor, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, activateAtStart, 
                deactivateAtEnd, timeUnscaled, EaseType.InOutSine);   
        }
#endregion

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale,
            float animationTime, EaseType easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            // Cache transform
            Transform objectToScaleT = objectToScale.transform;

            if (activateAtStart)
            {
                objectToScale.SetActive(true);
            }

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                easedTime = GetEasedTime(easeType, counter / animationTime);

                objectToScaleT.localScale = Vector3.LerpUnclamped(startScale, endScale, easedTime);

                yield return null;
            }

            // guarantee end scale
            objectToScaleT.localScale = endScale;

            if (deactivateAtEnd)
            {
                objectToScale.SetActive(false);
            }
        }

#region ScaleObject overloads
        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime, EaseType easeType)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, easeType, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime, EaseType easeType, bool timeUnscaled)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, easeType, false, false, timeUnscaled);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, EaseType.OutSine, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime, EaseType easeType)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, easeType, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime, EaseType easeType, bool timeUnscaled)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, easeType, false, false, timeUnscaled);
        }
#endregion
        

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, string textInFront,
            string textAtEnd, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled, EaseType easeType)
        {
            float counter = 0f;
            float percentComplete;
            float floatValue;
            int displayValue;

            System.Action<string> setter = (x) => {};

            if (activateAtStart)
            {
                objectWithTextComponent.SetActive(true);
            }

            // Cache text component
            if (objectWithTextComponent.GetComponent<Text>() != null)
            {
                Text textComponent = objectWithTextComponent.GetComponent<Text>();
                setter = (x) => textComponent.text = x;
            }
            else if (objectWithTextComponent.GetComponent<TextMeshPro>() != null)
            {
                TextMeshPro tmpComponent = objectWithTextComponent.GetComponent<TextMeshPro>();
                setter = (x) => tmpComponent.text = x;
            }
            else if (objectWithTextComponent.GetComponent<TextMeshProUGUI>() != null)
            {
                TextMeshProUGUI tmpComponent = objectWithTextComponent.GetComponent<TextMeshProUGUI>();
                setter = (x) => tmpComponent.text = x;
            }

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                percentComplete = GetEasedTime(easeType, counter / animationTime);

                floatValue = Mathf.Round(percentComplete * (endValue - startValue) + startValue);
                displayValue = (int)floatValue;
                setter(textInFront + displayValue.ToString() + textAtEnd);

                yield return null;
            }

            // guarantee correct end value
            setter(textInFront + endValue.ToString() + textAtEnd);

            if (deactivateAtEnd)
            {
                objectWithTextComponent.SetActive(false);
            }
        }

#region CountUpObject overloads
        private static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                false, false, false, EaseType.linear);
        }

        private static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                false, false, false, EaseType.linear);
        }

        private static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime, EaseType easeType)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                false, false, false, easeType);
        }

        private static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, EaseType easeType)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                false, false, false, easeType);
        }

        private static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime, bool timeUnscaled, EaseType easeType)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                false, false, timeUnscaled, easeType);
        }

        private static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, bool timeUnscaled, EaseType easeType)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                false, false, timeUnscaled, easeType);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, string textInFront,
            string textAtEnd, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, textInFront, textAtEnd, 
                activateAtStart, deactivateAtEnd, timeUnscaled, EaseType.linear);
        }
#endregion
        
        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, 
            bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled, EaseType easeType)
        {
            float counter = 0f;
            float percentComplete;

            // Cache image component
            Image image;

            if (objectWithImage.GetComponent<Image>() != null)
                image = objectWithImage.GetComponent<Image>();
            else
                yield break;

            if (activateAtStart)
            {
                objectWithImage.SetActive(true);
            }

            while (counter < timeToFill)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                percentComplete = GetEasedTime(easeType, counter / timeToFill);
                image.fillAmount = startFill + percentComplete * (endFill - startFill);

                yield return null;
            }

            // Guarantee correct end fill amount
            image.fillAmount = endFill;

            if (deactivateAtEnd)
            {
                objectWithImage.SetActive(false);
            }
        }

#region FillBar overloads
        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, false, false, false, EaseType.linear);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, false, false, false, EaseType.linear);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill, EaseType easeType)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, false, false, false, easeType);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, EaseType easeType)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, false, false, false, easeType);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill, bool timeUnscaled, EaseType easeType)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, bool timeUnscaled, EaseType easeType)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, false, false, timeUnscaled, easeType);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, 
            bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, activateAtStart, deactivateAtEnd, timeUnscaled, EaseType.linear);
        }
        #endregion

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, bool timeUnscaled, EaseType easeType)
        {
            float counter = 0f;

            while (counter < timeToFade)
            {
                if (timeUnscaled)
                {
                    counter += Time.unscaledDeltaTime;
                }
                else
                {
                    counter += Time.deltaTime;
                }

                audioSource.volume = Mathf.LerpUnclamped(startVolume, endVolume, GetEasedTime(easeType, counter / timeToFade));

                yield return null;
            }

            // Guarantee end volume
            audioSource.volume = endVolume;
        }

#region FadeAudioSource overloads
        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, false, EaseType.linear);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, false, EaseType.linear);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume, EaseType easeType)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, false, easeType);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, EaseType easeType)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, false, easeType);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume, bool timeUnscaled, EaseType easeType)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, timeUnscaled, easeType);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, bool timeUnscaled)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, timeUnscaled, EaseType.linear);
        }
#endregion

#region Easing Functions
        // Various constants used in the easing calculations
        private static readonly float c1 = 1.70158f;
        private static readonly float c2 = c1 * 1.525f;
        private static readonly float c3 = c1 + 1;
        private static readonly float c4 = 2 * Mathf.PI / 3;
        private static readonly float c5 = 2 * Mathf.PI / 4.5f;
        private static readonly float n1 = 7.5625f;
        private static readonly float d1 = 2.75f;

        /// <summary>
        /// Support for the deprecated ease in/out function
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private static float EaseInOutOld(float x)
        {
            return x * x * (3.0f - 2.0f * x);
        }

        /// <summary>
        /// Linear 'easing' (this is only really here to keep consistent syntax)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseLinear(float x)
        {
            return x;
        }

        /// <summary>
        /// https://easings.net/#easeInSine
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInSine(float x)
        {
            return 1 - Mathf.Cos(x * Mathf.PI / 2);
        }

        /// <summary>
        /// https://easings.net/#easeOutSine
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutSine(float x)
        {
            return Mathf.Sin(x * Mathf.PI / 2);
        }

        /// <summary>
        /// https://easings.net/#easeInOutSine
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutSine(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }

        /// <summary>
        /// https://easings.net/#easeInQuad
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInQuad(float x)
        {
            return x * x;
        }
        
        /// <summary>
        /// https://easings.net/#easeOutQuad
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutQuad(float x)
        {
            return 1 - (1 - x) * (1 - x);
        }

        /// <summary>
        /// https://easings.net/#easeInOutQuad
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutQuad(float x)
        {
            return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
        }

        /// <summary>
        /// https://easings.net/#easeInCubic
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInCubic(float x)
        {
            return x * x * x;        
        }

        /// <summary>
        /// https://easings.net/#easeOutCubic
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutCubic(float x)
        {
            return 1 - Mathf.Pow(1 - x, 3);    
        }

        /// <summary>
        /// https://easings.net/#easeInOutCubic
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutCubic(float x)
        {
            return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;    
        }

        /// <summary>
        /// https://easings.net/#easeInQuart
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInQuart(float x)
        {
            return x * x * x * x;
        }

        /// <summary>
        /// https://easings.net/#easeOutQuart
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutQuart(float x)
        {
            return 1 - Mathf.Pow(1 - x, 4);
        }

        /// <summary>
        /// https://easings.net/#easeInOutQuart
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutQuart(float x)
        {
            return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        }

        /// <summary>
        /// https://easings.net/#easeInQuint
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInQuint(float x)
        {
            return x * x * x * x * x;
        }

        /// <summary>
        /// https://easings.net/#easeOutQuint
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutQuint(float x)
        {
            return 1 - Mathf.Pow(1 - x, 5);
        }

        /// <summary>
        /// https://easings.net/#easeInOutQuint
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutQuint(float x)
        {
            return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
        }

        /// <summary>
        /// https://easings.net/#easeInExpo
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInExpo(float x)
        {
            return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
        }

        /// <summary>
        /// https://easings.net/#easeOutExpo
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutExpo(float x)
        {
            return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
        }

        /// <summary>
        /// https://easings.net/#easeInOutExpo
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutExpo(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
                : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
        }

        /// <summary>
        /// https://easings.net/#easeInCirc
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInCirc(float x)
        {
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
        }

        /// <summary>
        /// https://easings.net/#easeOutCirc
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutCirc(float x)
        {
            return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
        }

        /// <summary>
        /// https://easings.net/#easeInOutCirc
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutCirc(float x)
        {
            return x < 0.5
                ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
        }

        /// <summary>
        /// https://easings.net/#easeInBack
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInBack(float x)
        {
            return c3 * x * x * x - c1 * x * x;
        }

        /// <summary>
        /// https://easings.net/#easeOutBack
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutBack(float x)
        {
            return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
        }

        /// <summary>
        /// https://easings.net/#easeInOutBack
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutBack(float x)
        {
            return x < 0.5
                ? Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2) / 2
                : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }    
        
        /// <summary>
        /// https://easings.net/#easeInElastic
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInElastic(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
        }

        /// <summary>
        /// https://easings.net/#easeOutElastic
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutElastic(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
        }

        /// <summary>
        /// https://easings.net/#easeInOutElastic
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutElastic(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : x < 0.5
                ? -(Mathf.Pow(2, 20 * x - 10) * Mathf.Sin((20 * x - 11.125f) * c5)) / 2
                : Mathf.Pow(2, -20 * x + 10) * Mathf.Sin((20 * x - 11.125f) * c5) / 2 + 1;
        }

        /// <summary>
        /// https://easings.net/#easeInBounce
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInBounce(float x)
        {
            return 1 - EaseOutBounce(1 - x);
        }

        /// <summary>
        /// https://easings.net/#easeOutBounce
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseOutBounce(float x)
        {
            if (x < 1 / d1) 
            {
                return n1 * x * x;
            } 
            else if (x < 2 / d1) 
            {
                return n1 * (x -= 1.5f / d1) * x + 0.75f;
            } 
            else if (x < 2.5 / d1) 
            {
                return n1 * (x -= 2.25f / d1) * x + 0.9375f;
            } 
            else 
            {
                return n1 * (x -= 2.625f / d1) * x + 0.984375f;
            }
        }
        
        /// <summary>
        /// https://easings.net/#easeInOutBounce
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float EaseInOutBounce(float x)
        {
            return x < 0.5
                ? (1 - EaseOutBounce(1 - 2 * x)) / 2
                : (1 + EaseOutBounce(2 * x - 1)) / 2;
        }
#endregion
    
#region Helper Functions
        /// <summary>
        /// Helper function for FadeObject. Gets the alpha of the specified game object (provided it has the right component on it)
        /// </summary>
        /// <returns></returns>
        private static float GetObjectAlpha(GameObject gameObject)
        {
            if (gameObject.GetComponent<SpriteRenderer>())
            {
                return gameObject.GetComponent<SpriteRenderer>().color.a;
            }
            else if (gameObject.GetComponent<CanvasGroup>())
            {
                return gameObject.GetComponent<CanvasGroup>().alpha;
            }
            else if (gameObject.GetComponent<Image>())
            {
                return gameObject.GetComponent<Image>().color.a;
            }
            else if (gameObject.GetComponent<Text>())
            {
                return gameObject.GetComponent<Text>().color.a;
            }
            else if (gameObject.GetComponent<TextMeshPro>())
            {
                return gameObject.GetComponent<TextMeshPro>().color.a;
            }
            else if (gameObject.GetComponent<TextMeshProUGUI>())
            {
                return gameObject.GetComponent<TextMeshProUGUI>().color.a;
            }
            else if (gameObject.GetComponent<RawImage>())
            {
                return gameObject.GetComponent<RawImage>().color.a;
            }
            else
            {
                Debug.LogWarning("Cound not find an appropriate component to get alpha from");
                return 0f;
            }
        }

        /// <summary>
        /// Helper function for ColorObject and FlashObject. Gets the alpha of the specified game object (provided it has the right component on it)
        /// </summary>
        /// <returns></returns>
        private static Color GetObjectColor(GameObject gameObject)
        {
            if (gameObject.GetComponent<SpriteRenderer>())
            {
                return gameObject.GetComponent<SpriteRenderer>().color;
            }
            else if (gameObject.GetComponent<Image>())
            {
                return gameObject.GetComponent<Image>().color;
            }
            else if (gameObject.GetComponent<Text>())
            {
                return gameObject.GetComponent<Text>().color;
            }
            else if (gameObject.GetComponent<TextMeshPro>())
            {
                return gameObject.GetComponent<TextMeshPro>().color;
            }
            else if (gameObject.GetComponent<TextMeshProUGUI>())
            {
                return gameObject.GetComponent<TextMeshProUGUI>().color;
            }
            else if (gameObject.GetComponent<RawImage>())
            {
                return gameObject.GetComponent<RawImage>().color;
            }
            else
            {
                Debug.LogWarning("Cound not find an appropriate component to get color from");
                return Color.white;
            }
        }

        /// <summary>
        /// Helper function for CountUpObject. Returns the int version of text that is currently displaying a number.
        /// </summary>
        /// <param name="objectWithTextComponent">A game object with a Text, TextMeshPro, or TextMeshProUGUI component</param>
        /// <returns></returns>
        private static int GetObjectTextInt(GameObject objectWithTextComponent)
        {
            Text textComponent;
            if (objectWithTextComponent.TryGetComponent(out textComponent))
            {
                return int.Parse(textComponent.GetComponent<Text>().text);
            }

            TextMeshPro tmpComponent;
            if (objectWithTextComponent.TryGetComponent(out tmpComponent))
            {
                return int.Parse(tmpComponent.text);
            }

            TextMeshProUGUI tmpUiComponent;
            if (objectWithTextComponent.TryGetComponent(out tmpUiComponent))
            {
                return int.Parse(tmpUiComponent.text);
            }

            Debug.LogWarning("Could not find an appropriate component on this object");
            return -1;
        }
#endregion
    }
}