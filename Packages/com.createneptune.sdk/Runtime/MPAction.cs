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

        // ***WARNING: THIS CAUSES PERFORMANCE ISSUES ON ANDROID DEVICES IF USED EXCESSIVELY OR ON LARGE OR TRANSPARENT OBJECTS. BEWARE!***
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

        public static IEnumerator FadeObject(Behaviour behaviorToFade, float timeToFade, float startAlpha, float endAlpha, bool activateAtStart,
           bool deactivateAtEnd, bool timeUnscaled)
        {
            if (activateAtStart)
            {
                behaviorToFade.enabled = true;
            }

            yield return FadeObject(behaviorToFade.gameObject, timeToFade, startAlpha, endAlpha, false, false, timeUnscaled);

            if (deactivateAtEnd)
            {
                behaviorToFade.enabled = false;
            }
        }

        public static IEnumerator FadeObject(GameObject objectToFade, float timeToFade, float startAlpha, float endAlpha, bool activateAtStart,
            bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;

            if (activateAtStart)
            {
                objectToFade.SetActive(true);
            }

            if (objectToFade.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer objectToFadeSpriteRenderer = objectToFade.GetComponent<SpriteRenderer>();

                // Get current color.
                Color currentColor = objectToFadeSpriteRenderer.color;

                while (counter <= timeToFade)
                {
                    objectToFadeSpriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b,
                        startAlpha + (endAlpha - startAlpha) * counter / timeToFade);

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
                objectToFadeSpriteRenderer.color = new Color(currentColor.r, currentColor.g, currentColor.b, endAlpha);
            }
            else if (objectToFade.GetComponent<CanvasGroup>() != null)
            {
                CanvasGroup objectToFadeImage = objectToFade.GetComponent<CanvasGroup>();

                while (counter <= timeToFade)
                {
                    objectToFadeImage.alpha =
                        startAlpha + (endAlpha - startAlpha) * counter / timeToFade;

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
                objectToFadeImage.alpha = endAlpha;
            }
            else if (objectToFade.GetComponent<Image>() != null)
            {
                Image objectToFadeImage = objectToFade.GetComponent<Image>();

                // Get current color.
                Color currentColor = objectToFadeImage.color;

                while (counter <= timeToFade)
                {
                    objectToFadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b,
                        startAlpha + (endAlpha - startAlpha) * counter / timeToFade);

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
                objectToFadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, endAlpha);
            }
            else if (objectToFade.GetComponent<Text>() != null)
            {
                Text objectToFadeImage = objectToFade.GetComponent<Text>();

                // Get current color.
                Color currentColor = objectToFadeImage.color;

                while (counter <= timeToFade)
                {
                    objectToFadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b,
                        startAlpha + (endAlpha - startAlpha) * counter / timeToFade);

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
                objectToFadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, endAlpha);
            }

            else if (objectToFade.GetComponent<RawImage>() != null)
            {
                RawImage objectToFadeImage = objectToFade.GetComponent<RawImage>();

                // Get current color.
                Color currentColor = objectToFadeImage.color;

                while (counter <= timeToFade)
                {
                    objectToFadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b,
                        startAlpha + (endAlpha - startAlpha) * counter / timeToFade);

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
                objectToFadeImage.color = new Color(currentColor.r, currentColor.g, currentColor.b, endAlpha);
            }
            else
            {
                yield break;
            }

            if (deactivateAtEnd)
            {
                objectToFade.SetActive(false);
            }
        }

        public static IEnumerator ColorObject(GameObject objectToColor, float timeToFade, Color startColor, Color endColor, bool activateAtStart,
            bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;

            if (activateAtStart)
            {
                objectToColor.SetActive(true);
            }

            if (objectToColor.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer objectToColorSpriteRenderer = objectToColor.GetComponent<SpriteRenderer>();

                while (counter <= timeToFade)
                {
                    objectToColorSpriteRenderer.color = startColor + (endColor - startColor) * (counter / timeToFade);

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

                // guarantee end color
                objectToColorSpriteRenderer.color = endColor;
            }
            else if (objectToColor.GetComponent<Image>() != null)
            {
                Image objectToColorImage = objectToColor.GetComponent<Image>();

                while (counter <= timeToFade)
                {
                    objectToColorImage.color = startColor + (endColor - startColor) * (counter / timeToFade);

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
                objectToColorImage.color = endColor;
            }
            else if (objectToColor.GetComponent<MeshRenderer>() != null)
            {
                MeshRenderer objectToColorRenderer = objectToColor.GetComponent<MeshRenderer>();

                while (counter <= timeToFade)
                {
                    objectToColorRenderer.material.color = startColor + (endColor - startColor) * (counter / timeToFade);

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
                objectToColorRenderer.material.color = endColor;
            }
            else if (objectToColor.GetComponent<SkinnedMeshRenderer>() != null)
            {
                SkinnedMeshRenderer objectToColorRenderer = objectToColor.GetComponent<SkinnedMeshRenderer>();

                while (counter <= timeToFade)
                {
                    objectToColorRenderer.material.color = startColor + (endColor - startColor) * (counter / timeToFade);

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
                objectToColorRenderer.material.color = endColor;
            }
            else if (objectToColor.GetComponent<TextMeshProUGUI>() != null)
            {
                TextMeshProUGUI textToColor = objectToColor.GetComponent<TextMeshProUGUI>();

                while (counter <= timeToFade)
                {
                    textToColor.color = startColor + (endColor - startColor) * (counter / timeToFade);

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
                textToColor.color = endColor;
            }
            else
            {
                yield break;
            }

            if (deactivateAtEnd)
            {
                objectToColor.SetActive(false);
            }
        }

        public static IEnumerator FlashAnimation(GameObject objectToFlash, float flashInterval,
            float totalTime, Color startColor, Color endColor, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            int numFlashes = (int)(totalTime / flashInterval);

            if (activateAtStart)
            {
                objectToFlash.SetActive(true);
            }

            for (int i = 0; i < numFlashes; i++)
            {
                yield return ColorObject(objectToFlash, flashInterval, startColor, endColor, false, false, timeUnscaled);

                yield return ColorObject(objectToFlash, flashInterval, endColor, startColor, false, false, timeUnscaled);
            }

            if (deactivateAtEnd)
            {
                objectToFlash.SetActive(false);
            }
        }

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

        public static IEnumerator CountUpObject(GameObject objectWithTextComponent, int startValue, int endValue, float animationTime, string textInFront,
            string textAtEnd, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
        {
            float counter = 0f;
            float percentComplete;
            float floatValue;
            int displayValue;

            if (activateAtStart)
            {
                objectWithTextComponent.SetActive(true);
            }

            // Cache text component
            if (objectWithTextComponent.GetComponent<Text>() != null)
            {
                Text textComponent = objectWithTextComponent.GetComponent<Text>();

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

                    percentComplete = counter / animationTime;

                    floatValue = Mathf.Round(percentComplete * (endValue - startValue) + startValue);
                    displayValue = (int)floatValue;
                    textComponent.text = textInFront + displayValue.ToString() + textAtEnd;

                    yield return null;
                }

                // guarantee correct end value
                textComponent.text = textInFront + endValue.ToString() + textAtEnd;
            }
            else if (objectWithTextComponent.GetComponent<TextMeshPro>() != null)
            {
                TextMeshPro tmpComponent = objectWithTextComponent.GetComponent<TextMeshPro>();

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

                    percentComplete = counter / animationTime;

                    floatValue = Mathf.Round(percentComplete * (endValue - startValue) + startValue);
                    displayValue = (int)floatValue;
                    tmpComponent.text = textInFront + displayValue.ToString() + textAtEnd;

                    yield return null;
                }

                // guarantee correct end value
                tmpComponent.text = textInFront + endValue.ToString() + textAtEnd;
            }
            else if (objectWithTextComponent.GetComponent<TextMeshProUGUI>() != null)
            {
                TextMeshProUGUI tmpComponent = objectWithTextComponent.GetComponent<TextMeshProUGUI>();

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

                    percentComplete = counter / animationTime;

                    floatValue = Mathf.Round(percentComplete * (endValue - startValue) + startValue);
                    displayValue = (int)floatValue;
                    tmpComponent.text = textInFront + displayValue.ToString() + textAtEnd;

                    yield return null;
                }

                // guarantee correct end value
                tmpComponent.text = textInFront + endValue.ToString() + textAtEnd;
            }

            if (deactivateAtEnd)
            {
                objectWithTextComponent.SetActive(false);
            }
        }

        public static IEnumerator FillBar(GameObject objectWithImage, float timeToFill, float startFill, float endFill, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                percentComplete = counter / timeToFill;
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

        public static IEnumerator FadeAudioSource(AudioSource audioSource, float timeToFade, float startVolume, float endVolume, bool timeUnscaled)
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

                audioSource.volume = Mathf.LerpUnclamped(startVolume, endVolume, counter / timeToFade);

                yield return null;
            }

            // Guarantee end volume
            audioSource.volume = endVolume;
        }
    }
}