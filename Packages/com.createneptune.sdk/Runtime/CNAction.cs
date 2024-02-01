using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace CreateNeptune
{
    /// <summary>
    /// Animation tweens with adjustable timings using coroutines.
    /// </summary>
    public static class CNAction
    {
        public static IEnumerator RotateObject(GameObject rotateObject, bool local, float animationTime, Vector3 startRotation,
            Vector3 endRotation, CNEase.EasingFunc easingFunc, bool timeUnscaled)
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

                easedTime = easingFunc(counter / animationTime);

                if (local)
                    rotateObjectT.localRotation = Quaternion.LerpUnclamped(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), easedTime);
                else
                    rotateObjectT.rotation = Quaternion.LerpUnclamped(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), easedTime);

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
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, CNEase.Linear, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EasingFunc easingFunc)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, easingFunc, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EaseType easingType)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, CNEase.GetEasingFunc(easingType), false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, easingFunc, timeUnscaled);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, false, animationTime, rotateObject.transform.rotation.eulerAngles, endRotation, CNEase.GetEasingFunc(easingType), timeUnscaled);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, CNEase.Linear, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EasingFunc easingFunc)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, easingFunc, false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EaseType easingType)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, CNEase.GetEasingFunc(easingType), false);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, easingFunc, timeUnscaled);
        }

        public static IEnumerator RotateObject(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, false, animationTime, startRotation, endRotation, CNEase.GetEasingFunc(easingType), timeUnscaled);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, CNEase.Linear, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EasingFunc easingFunc)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, easingFunc, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EaseType easeType)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, CNEase.GetEasingFunc(easeType), false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, easingFunc, timeUnscaled);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 endRotation, CNEase.EaseType easeType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, true, animationTime, rotateObject.transform.localRotation.eulerAngles, endRotation, CNEase.GetEasingFunc(easeType), timeUnscaled);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, CNEase.Linear, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EasingFunc easingFunc)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, easingFunc, false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EaseType easingType)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, CNEase.GetEasingFunc(easingType), false);
        }

        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, easingFunc, timeUnscaled);
        }
        
        public static IEnumerator RotateObjectLocal(GameObject rotateObject, float animationTime, Vector3 startRotation, Vector3 endRotation, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return RotateObject(rotateObject, true, animationTime, startRotation, endRotation, CNEase.GetEasingFunc(easingType), timeUnscaled);
        }
#endregion

        public static IEnumerator MoveObject(GameObject moveObject, bool localPosition, float animationTime, Vector3 startPosition, Vector3 endPosition,
            CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                easedTime = easingFunc(counter / animationTime);

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
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, CNEase.Linear, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EasingFunc easingFunc)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, easingFunc, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EaseType easingType)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.position, endPosition, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, CNEase.Linear, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EasingFunc easingFunc)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, easingFunc, false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EaseType easingType)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObject(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, moveObject.transform.localPosition, endPosition, CNEase.Linear, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EasingFunc easingFunc)
        {
            yield return MoveObject(moveObject, true, animationTime, moveObject.transform.localPosition, endPosition, easingFunc, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EaseType easingType)
        {
            yield return MoveObject(moveObject, true, animationTime, moveObject.transform.localPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, true, animationTime, moveObject.transform.localPosition, endPosition, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 endPosition, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, true, animationTime, moveObject.transform.localPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition)
        {
            yield return MoveObject(moveObject, false, animationTime, startPosition, endPosition, CNEase.Linear, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EasingFunc easingFunc)
        {
            yield return MoveObject(moveObject, true, animationTime, startPosition, endPosition, easingFunc, false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EaseType easingType)
        {
            yield return MoveObject(moveObject, true, animationTime, startPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, true, animationTime, startPosition, endPosition, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator MoveObjectLocal(GameObject moveObject, float animationTime, Vector3 startPosition, Vector3 endPosition, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return MoveObject(moveObject, true, animationTime, startPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }
#endregion

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition,
            CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                easedTime = easingFunc(counter / animationTime);

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
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, CNEase.Linear, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition, CNEase.EasingFunc easingFunc)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, easingFunc, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition, CNEase.EaseType easingType)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 endPosition, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return MoveCanvasObject(moveObject, animationTime, moveObject.GetComponent<RectTransform>().anchoredPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, CNEase.Linear, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition, CNEase.EasingFunc easingFunc)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, easingFunc, false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition, CNEase.EaseType easingType)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator MoveCanvasObject(GameObject moveObject, float animationTime, Vector2 startPosition, Vector2 endPosition, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return MoveCanvasObject(moveObject, animationTime, startPosition, endPosition, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }
#endregion

        /// ***WARNING: THIS CAUSES PERFORMANCE ISSUES ON ANDROID DEVICES IF USED EXCESSIVELY OR ON LARGE OR TRANSPARENT OBJECTS. BEWARE!***
        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale,
            CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                easedTime = easingFunc(counter / animationTime);

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
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, CNEase.Linear, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale, CNEase.EasingFunc easingFunc)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, easingFunc, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale, CNEase.EaseType easingType)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 endScale, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, scaleObject.GetComponent<RectTransform>().localScale, endScale, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, CNEase.Linear, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale, CNEase.EasingFunc easingFunc)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, easingFunc, false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale, CNEase.EaseType easingType)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector3 startScale, Vector3 endScale, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return ScaleCanvasObject(scaleObject, animationTime, startScale, endScale, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }
#endregion

        public static IEnumerator FadeObject(GameObject objectToFade, float timeToFade, float startAlpha, float endAlpha,
            CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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
                Text objectToFadeText = objectToFade.GetComponent<Text>();
                setter = (x) => 
                {
                    Color newColor = objectToFadeText.color;
                    newColor.a = x;
                    objectToFadeText.color = newColor;
                };
            }
            else if (objectToFade.GetComponent<TextMeshPro>())
            {
                TextMeshPro objectToFadeText = objectToFade.GetComponent<TextMeshPro>();
                setter = (x) =>
                {
                    Color newColor = objectToFadeText.color;
                    newColor.a = x;
                    objectToFadeText.color = newColor;
                };
            }
            else if (objectToFade.GetComponent<TextMeshProUGUI>())
            {
                TextMeshProUGUI objectToFadeText = objectToFade.GetComponent<TextMeshProUGUI>();
                setter = (x) =>
                {
                    Color newColor = objectToFadeText.color;
                    newColor.a = x;
                    objectToFadeText.color = newColor;
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
                setter(startAlpha + (endAlpha - startAlpha) * easingFunc(counter / timeToFade));

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
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, CNEase.Linear, false, false, false);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float endAlpha) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, GetObjectAlpha(behaviorToFade.gameObject), endAlpha, CNEase.Linear, false, false, false);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, CNEase.Linear, false, false, false);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float startAlpha, float endAlpha) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, startAlpha, endAlpha, CNEase.Linear, false, false, false);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha, CNEase.EasingFunc easingFunc) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, easingFunc, false, false, false);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha, CNEase.EaseType easingType) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float endAlpha, CNEase.EasingFunc easingFunc) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, GetObjectAlpha(behaviorToFade.gameObject), endAlpha, easingFunc, false, false, false);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float endAlpha, CNEase.EaseType easingType) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, GetObjectAlpha(behaviorToFade.gameObject), endAlpha, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EasingFunc easingFunc) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, easingFunc, false, false, false);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EaseType easingType) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EasingFunc easingFunc) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, startAlpha, endAlpha, easingFunc, false, false, false);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EaseType easingType) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, startAlpha, endAlpha, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha, CNEase.EasingFunc easingFunc, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float endAlpha, CNEase.EaseType easingType, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, GetObjectAlpha(objectToFade), endAlpha, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float endAlpha, CNEase.EasingFunc easingFunc, bool timeUnscaled) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, GetObjectAlpha(behaviorToFade.gameObject), endAlpha, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float endAlpha, CNEase.EaseType easingType, bool timeUnscaled) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, GetObjectAlpha(behaviorToFade.gameObject), endAlpha, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EasingFunc easingFunc, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EaseType easingType, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EasingFunc easingFunc, bool timeUnscaled) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, startAlpha, endAlpha, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float startAlpha, float endAlpha, CNEase.EaseType easingType, bool timeUnscaled) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, startAlpha, endAlpha, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeTofade, float startAlpha, float endAlpha, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled) 
        {
            yield return FadeObject(objectToFade, timeTofade, startAlpha, endAlpha, CNEase.Linear, activateAtStart, deactivateAtEnd, timeUnscaled);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeTofade, float startAlpha, float endAlpha, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled) 
        {
            yield return FadeObject(behaviorToFade, timeTofade, startAlpha, endAlpha, CNEase.Linear, activateAtStart, deactivateAtEnd, timeUnscaled);
        }

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeToFade, float startAlpha, float endAlpha, CNEase.EasingFunc easingFunc,
            bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            if (activateAtStart)
            {
                behaviorToFade.enabled = true;
            }

            yield return FadeObject(behaviorToFade.gameObject, timeToFade, startAlpha, endAlpha, easingFunc, false, false, timeUnscaled);

            if (deactivateAtEnd)
            {
                behaviorToFade.enabled = false;
            }
        }
        
        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeToFade, float startAlpha, float endAlpha, CNEase.EaseType easingType,
            bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            if (activateAtStart)
            {
                behaviorToFade.enabled = true;
            }

            yield return FadeObject(behaviorToFade.gameObject, timeToFade, startAlpha, endAlpha, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);

            if (deactivateAtEnd)
            {
                behaviorToFade.enabled = false;
            }
        }
#endregion

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, CNEase.EasingFunc easingFunc,
            bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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
            else if (objectToColor.GetComponent<TextMesh>() != null)
            {
                TextMesh textToColor = objectToColor.GetComponent<TextMesh>();
                setter = (x) => textToColor.color = x;
            }
            else if (objectToColor.GetComponent<Text>() != null)
            {
                Text textToColor = objectToColor.GetComponent<Text>();
                setter = (x) => textToColor.color = x;
            }
            else
            {
                yield break;
            }

            while (counter <= timeToFade)
            {
                setter(startColor + (endColor - startColor) * easingFunc(counter / timeToFade));

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
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, CNEase.Linear, false, false, false);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, CNEase.Linear, false, false, false);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor, CNEase.EasingFunc easingFunc)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, easingFunc, false, false, false);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor, CNEase.EaseType easingType)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, CNEase.EasingFunc easingFunc)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, easingFunc, false, false, false);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, CNEase.EaseType easingType)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color endColor, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return ColorObject(objectToColor, timeToFade, GetObjectColor(objectToColor), endColor, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return ColorObject(objectToColor, timeToFade, startColor, endColor, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }
#endregion
        
        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval,
            float totalTime, Color startColor, Color endColor, CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            int numFlashes = (int)(totalTime / flashInterval);

            if (activateAtStart)
            {
                objectToFlash.SetActive(true);
            }

            for (int i = 0; i < numFlashes; i++)
            {
                yield return ColorObject(objectToFlash, flashInterval, startColor, endColor, easingFunc, false, false, timeUnscaled);

                yield return ColorObject(objectToFlash, flashInterval, endColor, startColor, easingFunc, false, false, timeUnscaled);
            }

            if (deactivateAtEnd)
            {
                objectToFlash.SetActive(false);
            }
        }

#region FlashAnimation overloads
        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, CNEase.InOutSine,
                false, false, false);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, CNEase.InOutSine,
                false, false, false);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor, CNEase.EasingFunc easingFunc)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, easingFunc,
                false, false, false);
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor, CNEase.EaseType easingType)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, CNEase.GetEasingFunc(easingType),
                false, false, false);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor, CNEase.EasingFunc easingFunc)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, easingFunc,
                false, false, false);   
        }
        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor, CNEase.EaseType easingType)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, CNEase.GetEasingFunc(easingType),
                false, false, false);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor,
            CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, easingFunc,
                false, false, timeUnscaled);   
        }
        
        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color endColor,
            CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, GetObjectColor(objectToFlash), endColor, CNEase.GetEasingFunc(easingType),
                false, false, timeUnscaled);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor,
            CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, easingFunc,
                false, false, timeUnscaled);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor, Color endColor,
            CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, CNEase.GetEasingFunc(easingType),
                false, false, timeUnscaled);   
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval, float totalTime, Color startColor,
            Color endColor, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            yield return FlashAnimation(objectToFlash, flashInterval, totalTime, startColor, endColor, CNEase.InOutSine, 
                activateAtStart, deactivateAtEnd, timeUnscaled);   
        }
#endregion

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale,
            float animationTime, CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                easedTime = easingFunc(counter / animationTime);

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
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, CNEase.Linear, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime, CNEase.EasingFunc easingFunc)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, easingFunc, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime, CNEase.EaseType easingType)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 endScale, float animationTime, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return ScaleObject(objectToScale, objectToScale.transform.localScale, endScale, animationTime, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, CNEase.Linear, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime, CNEase.EasingFunc easingFunc)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, easingFunc, false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime, CNEase.EaseType easingType)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator ScaleObject(GameObject objectToScale, Vector3 startScale, Vector3 endScale, float animationTime, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return ScaleObject(objectToScale, startScale, endScale, animationTime, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }
#endregion
        
        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, string textInFront,
            string textAtEnd, CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                percentComplete = easingFunc(counter / animationTime);

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
        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                CNEase.Linear, false, false, false);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                CNEase.Linear, false, false, false);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime, CNEase.EasingFunc easingFunc)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                easingFunc, false, false, false);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime, CNEase.EaseType easingType)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, CNEase.EasingFunc easingFunc)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                easingFunc, false, false, false);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, CNEase.EaseType easingType)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int endValue, float animationTime, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return CountUpObject(objectWithTextComponent, GetObjectTextInt(objectWithTextComponent), endValue, animationTime, "", "",
                CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, "", "",
                CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, string textInFront,
            string textAtEnd, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            yield return CountUpObject(objectWithTextComponent, startValue, endValue, animationTime, textInFront, textAtEnd, 
                CNEase.Linear, activateAtStart, deactivateAtEnd, timeUnscaled);
        }
#endregion
        
        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, 
            CNEase.EasingFunc easingFunc, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                percentComplete = easingFunc(counter / timeToFill);
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
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, CNEase.Linear, false, false, false);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, CNEase.Linear, false, false, false);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill, CNEase.EasingFunc easingFunc)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, easingFunc, false, false, false);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill, CNEase.EaseType easingType)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, CNEase.EasingFunc easingFunc)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, easingFunc, false, false, false);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, CNEase.EaseType easingType)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, CNEase.GetEasingFunc(easingType), false, false, false);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float endFill, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return FillBar(objectWithImage, timeToFill, objectWithImage.GetComponent<Image>().fillAmount, endFill, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, CNEase.EasingFunc easingFunc, bool timeUnscaled)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, easingFunc, false, false, timeUnscaled);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, CNEase.EaseType easingType, bool timeUnscaled)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, CNEase.GetEasingFunc(easingType), false, false, timeUnscaled);
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, 
            bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            yield return FillBar(objectWithImage, timeToFill, startFill, endFill, CNEase.Linear, activateAtStart, deactivateAtEnd, timeUnscaled);
        }
#endregion

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, CNEase.EasingFunc easingFunc, bool timeUnscaled)
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

                audioSource.volume = Mathf.LerpUnclamped(startVolume, endVolume, easingFunc(counter / timeToFade));

                yield return null;
            }

            // Guarantee end volume
            audioSource.volume = endVolume;
        }

#region FadeAudioSource overloads
        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, CNEase.Linear, false);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, CNEase.Linear, false);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume, CNEase.EasingFunc easingFunc)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, easingFunc, false);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume, CNEase.EaseType easingType)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, CNEase.GetEasingFunc(easingType), false);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, CNEase.EasingFunc easingFunc)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, easingFunc, false);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, CNEase.EaseType easingType)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, CNEase.GetEasingFunc(easingType), false);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume, bool timeUnscaled, CNEase.EasingFunc easingFunc)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, easingFunc, timeUnscaled);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float endVolume, bool timeUnscaled, CNEase.EaseType easingType)
        {
            yield return FadeAudioSource(audioSource, timeToFade, audioSource.volume, endVolume, CNEase.GetEasingFunc(easingType), timeUnscaled);
        }

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, bool timeUnscaled)
        {
            yield return FadeAudioSource(audioSource, timeToFade, startVolume, endVolume, CNEase.Linear, timeUnscaled);
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
                Debug.LogError("Could not find an appropriate component to get alpha");
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
                Debug.LogError("Cound not find an appropriate component to get color");
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

            Debug.LogError("Could not find an appropriate component on this object");
            return -1;
        }
#endregion
    }
}
