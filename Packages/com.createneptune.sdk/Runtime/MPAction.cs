// Create Neptune SDK (c) 2021 Create Neptune LLC.
// All rights reserved.

namespace CreateNeptune
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public static class MPAction
    {
        public enum EaseType
        {
            easein, easeout, easeineaseout, linear
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

                if (easeType == EaseType.easein)
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeout)
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeineaseout)
                {
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                }
                else // linear
                {
                    easedTime = counter / animationTime;
                }

                if (local)
                    rotateObjectT.localRotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, easedTime));
                else
                    rotateObjectT.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, endRotation, easedTime));

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

                if (easeType == EaseType.easein)
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeout)
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeineaseout)
                {
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                }
                else // linear
                {
                    easedTime = counter / animationTime;
                }

                if (localPosition)
                {
                    moveObjectT.localPosition = Vector3.Lerp(startPosition, endPosition, easedTime);
                }
                else
                {
                    moveObjectT.position = Vector3.Lerp(startPosition, endPosition, easedTime);
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

                if (easeType == EaseType.easein)
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeout)
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeineaseout)
                {
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                }
                else // linear
                {
                    easedTime = counter / animationTime;
                }

                moveObjectT.anchoredPosition = Vector2.Lerp(startPosition, endPosition, easedTime);

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

                if (easeType == EaseType.easein)
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == EaseType.easeout)
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == EaseType.easeineaseout)
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                else // linear
                    easedTime = counter / animationTime;

                if (scaleObjectT != null)
                    scaleObjectT.localScale = Vector3.Lerp(startScale, endScale, easedTime);

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

                if (easeType == EaseType.easein)
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeout)
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == EaseType.easeineaseout)
                {
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                }
                else // linear
                {
                    easedTime = counter / animationTime;
                }

                objectToScaleT.localScale = Vector3.Lerp(startScale, endScale, easedTime);

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

                audioSource.volume = Mathf.Lerp(startVolume, endVolume, counter / timeToFade);

                yield return null;
            }

            // Guarantee end volume
            audioSource.volume = endVolume;
        }
    }
}