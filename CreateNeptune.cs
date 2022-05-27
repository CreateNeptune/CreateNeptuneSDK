// Create Neptune SDK (c) 2021 Create Neptune LLC.
// All rights reserved.

namespace CreateNeptune
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro;

    public class MPAction : MonoBehaviour
    {
        public static IEnumerator RotateObject(GameObject rotateObject, bool local, float animationTime, Vector3 startRotation, Vector3 endRotation, string easeType, bool timeUnscaled)
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

                if (easeType == "easein")
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeout")
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeineaseout")
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
            string easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                if (easeType == "easein")
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeout")
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeineaseout")
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
            string easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                if (easeType == "easein")
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeout")
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeineaseout")
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
        public static IEnumerator ScaleCanvasObject(GameObject scaleObject, float animationTime, Vector2 startScale, Vector2 endScale,
            string easeType, bool activateAtStart, bool deactivateAtEnd, bool timeUnscaled)
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

                if (easeType == "easein")
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == "easeout")
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == "easeineaseout")
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                else // linear
                    easedTime = counter / animationTime;

                if (scaleObjectT != null)
                    scaleObjectT.localScale = Vector2.Lerp(startScale, endScale, easedTime);

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
            float animationTime, string easeType, bool activateAtStart, bool deactivateAtEnd, bool destroyAtEnd, bool timeUnscaled)
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

                if (easeType == "easein")
                {
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeout")
                {
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                }
                else if (easeType == "easeineaseout")
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

            if (destroyAtEnd)
            {
                Destroy(objectToScale);
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

    public class CNExtensions : MonoBehaviour
    {
        public static IEnumerator CameraShake(float shakeDuration, float magnitude)
        {
            Transform camT = Camera.main.transform;
            Vector3 originalPosition = camT.localPosition;
            float counter = 0f;

            while (counter < shakeDuration)
            {
                float x = UnityEngine.Random.Range(-1f, 1f) * magnitude;
                float z = UnityEngine.Random.Range(-1f, 1f) * magnitude;

                camT.localPosition = new Vector3(originalPosition.x + x, originalPosition.y, originalPosition.z + z);

                counter += Time.deltaTime;

                yield return null;
            }

            camT.localPosition = originalPosition;
        }

        public static IEnumerator CameraPan(Camera cam, float animationTime, bool localPosition, Vector3 startPosition,
            Vector3 endPosition, float startSize, float endSize, string easeType, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            // Cache transform
            Transform camT = cam.transform;

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                    counter += Time.unscaledDeltaTime;
                else
                    counter += Time.deltaTime;

                if (easeType == "easein")
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == "easeout")
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == "easeineaseout")
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                else // linear
                    easedTime = counter / animationTime;

                if (localPosition)
                    camT.localPosition = Vector3.Lerp(startPosition, endPosition, easedTime);
                else
                    camT.position = Vector3.Lerp(startPosition, endPosition, easedTime);

                cam.orthographicSize = Mathf.Lerp(startSize, endSize, easedTime);

                yield return null;
            }

            // guarantee end position
            if (localPosition)
                camT.localPosition = endPosition;
            else
                camT.position = endPosition;
        }

        public static IEnumerator CameraRotate(Camera cam, float animationTime, bool localRotation, Quaternion startRotation,
            Quaternion endRotation, string easeType, bool timeUnscaled)
        {
            float counter = 0f;
            float easedTime;

            Transform camT = cam.transform;

            while (counter <= animationTime)
            {
                if (timeUnscaled)
                    counter += Time.unscaledDeltaTime;
                else
                    counter += Time.deltaTime;

                if (easeType == "easein")
                    easedTime = 1f - Mathf.Cos((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == "easeout")
                    easedTime = Mathf.Sin((counter / animationTime) * Mathf.PI * 0.5f);
                else if (easeType == "easeineaseout")
                    easedTime = (counter / animationTime) * (counter / animationTime) * (3.0f - 2.0f * (counter / animationTime));
                else // linear
                    easedTime = counter / animationTime;

                if (localRotation)
                    camT.localRotation = Quaternion.Lerp(startRotation, endRotation, easedTime);
                else
                    camT.rotation = Quaternion.Lerp(startRotation, endRotation, easedTime);

                yield return null;
            }

            // Guarantee end rotation.
            if (localRotation)
                camT.localRotation = endRotation;
            else
                camT.rotation = endRotation;
        }

        public static float RandGaussian(float mean, float standardDeviation)
        {
            float randNum = UnityEngine.Random.Range(0f, 100f);
            float norm;

            if (randNum < 2.5)
            {
                norm = 1f / 2.5f * randNum - 3f;
            }

            else if (randNum < 16)
            {
                norm = 1f / 13.5f * (randNum - 2.5f) - 2f;
            }

            else if (randNum < 50)
            {
                norm = 1f / 34f * (randNum - 16) - 1f;
            }

            else if (randNum < 84)
            {
                norm = 1f / 34f * (randNum - 50f);
            }

            else if (randNum < 97.5)
            {
                norm = 1f / 13.5f * (randNum - 84f) + 1f;
            }

            else
            {
                norm = 1f / 2.5f * (randNum - 97.5f) + 2f;
            }

            return norm * standardDeviation + mean;
        }

        // Create a GameObject pool of a certain size.
        public static void CreateObjectPool(List<GameObject> gameObjectList, GameObject gameObject, int poolSize, Transform parent, int physicsLayer)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject newGO = Instantiate(gameObject);
                newGO.layer = physicsLayer;
                newGO.SetActive(false);
                newGO.transform.parent = parent;
                gameObjectList.Add(newGO);
            }
        }

        // Get a pooled object in a certain orientation (like a bullet being shot).
        public static GameObject GetPooledObject(List<GameObject> objectPool, GameObject gameObject,
            int physicsLayer, Transform t, Vector3 positionOffset, Quaternion rotationOffset, bool ignoreParentTransform)
        {
            for (int i = 0; i < objectPool.Count; i++)
            {
                if (!objectPool[i].activeSelf)
                {
                    objectPool[i].SetActive(true);

                    // Set transform.
                    if (ignoreParentTransform)
                    {
                        objectPool[i].transform.position = positionOffset;
                        objectPool[i].transform.rotation = rotationOffset;
                    }
                    else
                    {
                        objectPool[i].transform.position = t.position + positionOffset;
                        objectPool[i].transform.rotation = t.rotation * rotationOffset;
                    }

                    return objectPool[i];
                }
            }

            // Otherwise instantiate a new object.
            GameObject newObject = Instantiate(gameObject);
            newObject.layer = physicsLayer;
            newObject.SetActive(false);
            objectPool.Add(newObject);

            // Set transform.
            if (ignoreParentTransform)
            {
                newObject.transform.position = positionOffset;
                newObject.transform.rotation = rotationOffset;
            }
            else
            {
                newObject.transform.position = t.position + positionOffset;
                newObject.transform.rotation = t.rotation * rotationOffset;
            }

            newObject.SetActive(true);

            return newObject;
        }

        // Return a rank from 1st to worst, allowing for ties
        public static int GetRankFromArray(int playerScore, int[] intArray, bool largestToSmallest)
        {
            // Create a copy of the array to sort to avoid changing original (arrays are reference types, n00b!)
            int[] copyArray = new int[intArray.Length];
            intArray.CopyTo(copyArray, 0);

            // Sort the copyArray (smallest to largest by default)
            Array.Sort(copyArray);

            // If bigger is better reverse the array and then find rank
            // NOTE: must do it this way so that we return best possible rank in the case of duplicates
            if (largestToSmallest)
            {
                Array.Reverse(copyArray);

                for (int i = 0; i < copyArray.Length; i++)
                {
                    if (playerScore >= copyArray[i])
                    {
                        return i + 1;
                    }
                }
            }
            else
            {
                // Check where playerScore falls in sorted array and return as rank
                for (int i = 0; i < copyArray.Length; i++)
                {
                    if (playerScore <= copyArray[i])
                    {
                        return i + 1;
                    }
                }
            }

            // Should never get here
            return copyArray.Length;
        }

        public static int SumArray(int[] arrayToSum)
        {
            int sum = 0;

            for (int i = 0; i < arrayToSum.Length; i++)
            {
                sum += arrayToSum[i];
            }

            return sum;
        }

        public static float SumArray(float[] arrayToSum)
        {
            float sum = 0;

            for (int i = 0; i < arrayToSum.Length; i++)
            {
                sum += arrayToSum[i];
            }

            return sum;
        }

        public static double SumArray(double[] arrayToSum)
        {
            double sum = 0;

            for (int i = 0; i < arrayToSum.Length; i++)
            {
                sum += arrayToSum[i];
            }

            return sum;
        }

        public static List<int> GetRandomSubsetList(List<int> originalList, int numRandomEntries)
        {
            List<int> newList = new List<int>();
            List<int> tempList = new List<int>(originalList);

            while (Mathf.Min(numRandomEntries, tempList.Count) > 0)
            {
                int randomNum = UnityEngine.Random.Range(0, tempList.Count);

                numRandomEntries--;

                newList.Add(tempList[randomNum]);

                tempList.RemoveAt(randomNum);
            }

            return newList;
        }

        public static List<float> GetRandomSubsetList(List<float> originalList, int numRandomEntries)
        {
            List<float> newList = new List<float>();
            List<float> tempList = new List<float>(originalList);

            while (Mathf.Min(numRandomEntries, tempList.Count) > 0)
            {
                int randomNum = UnityEngine.Random.Range(0, tempList.Count);

                numRandomEntries--;

                newList.Add(tempList[randomNum]);

                tempList.RemoveAt(randomNum);
            }

            return newList;
        }

        public static string FabricateName(string yourPlayerName)
        {
            string fabricatedName;

            do
            {
                // Pull a name from fakePlayerNames array OR first name / last name / number seeder based on random number
                int numberOfRandomNames = 2000;
                int randomSeed = UnityEngine.Random.Range(0, numberOfRandomNames);

                if (randomSeed < fakePlayerNames.Length)
                {
                    fabricatedName = fakePlayerNames[randomSeed];
                }
                else
                {
                    int newSeed = UnityEngine.Random.Range(0, 5);

                    if (newSeed == 0)
                    {
                        // Generate a player name first + last randomly with no number appendage
                        fabricatedName = fakeFirstName[UnityEngine.Random.Range(0, fakeFirstName.Length)] + fakeLastName[UnityEngine.Random.Range(0, fakeLastName.Length)];
                    }
                    else if (newSeed == 1)
                    {
                        // Generate a player name first + number with no last
                        fabricatedName = fakeFirstName[UnityEngine.Random.Range(0, fakeFirstName.Length)] + fakeNumber[UnityEngine.Random.Range(0, fakeNumber.Length)];
                    }
                    else if (newSeed == 2)
                    {
                        // Generate either a thematic + first + number OR a first + thematic + number
                        if (UnityEngine.Random.Range(0, 2) == 0)
                        {
                            fabricatedName = themeName[UnityEngine.Random.Range(0, themeName.Length)] + fakeFirstName[UnityEngine.Random.Range(0, fakeFirstName.Length)]
                                + fakeNumber[UnityEngine.Random.Range(0, fakeNumber.Length)];
                        }
                        else
                        {
                            fabricatedName = fakeFirstName[UnityEngine.Random.Range(0, fakeFirstName.Length)] + themeName[UnityEngine.Random.Range(0, themeName.Length)]
                                + fakeNumber[UnityEngine.Random.Range(0, fakeNumber.Length)];
                        }
                    }
                    else
                    {
                        // Generate a first + last + number player name
                        fabricatedName = fakeFirstName[UnityEngine.Random.Range(0, fakeFirstName.Length)] + fakeLastName[UnityEngine.Random.Range(0, fakeLastName.Length)]
                            + fakeNumber[UnityEngine.Random.Range(0, fakeNumber.Length)];
                    }
                }
                // if it's the same name as P1 check for a new name until you get one that isn't the same
            } while (yourPlayerName.Equals(fabricatedName));

            return fabricatedName;
        }

        public static IEnumerator WaitForFrames(int numFrames)
        {
            if (numFrames < 1)
                yield return null;

            for (int i = 0; i < numFrames; i++)
            {
                yield return null;
            }
        }

        public static string MakeCapitalized(string originalString)
        {
            if (originalString.Length == 0)
                return "";
            else if (originalString.Length == 1)
                return char.ToUpper(originalString[0]).ToString();
            else
                return char.ToUpper(originalString[0]) + originalString.Substring(1);
        }


        public static bool IsLayerInMask(int layer, LayerMask layerMask)
        {
            return ((1 << layer) & layerMask) > 0;
        }


        // Array of player names: we can keep adding to this, but keeping a minimum of 2000 names.
        // If don't have enough here, will autogenerate one.
        private static readonly string[] fakePlayerNames = {"Jamesman","PDPWario","phil4684","jvitale9","supadupaparatrpa","ryanf33","kcfagan1","themanjs2",
            "kfcLuvva","HeistoftheCentury","Skilllllz","NiGhT RiDa","jeffreysanchez","owentsai","saleem4192","CalTheBoxer","tombradyrulez12","Blade9803",
            "UltimateDB","Pandora55","MasterClasher","Theblackpanther","TwitchMitch","YouTube overL0rd","TyCobbBob","slapclam4","RuskieBabuski","Trite Duff",
            "napoleondynamite","TommyTooToned","peteisthebest","Pandamonium","Addicted2love","PalindromicFoe","porp0isesr0ck","dannydimes","fredsavage","ibeatthelaw",
            "clandestinepauper","CoolNickTheSlick","ArchDukeFranzFerdinand","calvinhobbes","cylindricalpapertube","AtlantaJames","WillSmith44",
            "Cabsarehere","mosdef","CheesyStoryBro","uniteandconquer","JacobJavits","djtrumpprez4lyfe","SaintBoris","Night Winger","SupermanInTheAir33","souljaboytellem",
            "ChefNancy","TwitchFarrad","SamuelClemens","DuncanTheGood","DopeSneakers","Clap Clap Em","Spokenwordsarenothing","AlvinTheChipmunk",
            "plantarfasciitis82","CarolinaHerrman","Testarossa1982","FrancescaLilyP","HankTheTank12","jasminberryz","Katanna3","stuuuuarttt","GoldmanZacks",
            "DevilsPeak","ChobaniIsMyLife","pandalover333","Wizard of Dope","hondaCRV7","teslamodelS","Blue Note G","carboncopys","GaussianDistribution",
            "Chevalier","thomas31898","LukeT89","lancethedancer","CharlieHustle","TheWhiteRose","ConanTheBarbarian","miketrouth45","IrreverentSamuel",
            "Robert5599","HBombLegacy","diabeticcat","GrindThoseCoins","PearlJam2002","nirvanaKurtC","mthatcher1991","BrettIsMyHomeboy","PlasticRecycling",
            "EliasJefferson22","VictoriaL18","SammyBecksss","LiberalLatvian","MichelleMyBelle","PattyBrooke12","theyachtsmanvic","TheresaSwellesley",
            "ingridBeez","suchan00ber","Glorious Balto","Tretiak Potato","Slapstick Accountant","MissyCarly","Domo Arigato Mr. Roboto","pucktotheface",
            "Credible Landslider","Censoredship","Penelopeeee","organicchiaseeds","chachachachacha","SordidSword","winniecooper","Allstarcentershen",
            "gabriellaishere","Lauren51782","Jennifer9493","blueeyedbeauty1999","HughWang1986","E11even7","Cindymartin2396","JohannaSchwartz23","IngridM29",
            "jamiecampooo","Srgnt007","Eskool16","winelover36","icepickkrp","kateTHEgreat","slamminsammy","IAmTheWalrus","ClevelandAnnie","shufflefingers",
            "c0reGam3r","TwitchHarryPots","ReleaseSteveWinters","ThanksObama","GandalfTheGrey","TwitchUrsula","bookwormbillie","Barishnikov",
            "ColdIcedTea23","Bledsoe1997","SidneyTheKidney","Chazzzzz","derekdonkey95","DannyRulermoustache","PatricioBombasto","cornhusker4life",
            "Blitzkrieg4u","mikey2legs","ESLCharlotte","despocitomami","L1GhTF00t","FrancescaLee3","JeffreyTPax","Devon5689","blastCellar4Wine",
            "Davidkrantz19","hakum34","MarkWeinstein7","JeffHalladay5","ChanTseee","scorpion3355","gobigred12","ganggreen92","goals92","WHaCKeD",
            "ChrisF2019","hockeyWFAN","ibleedblacknyellow","Catastrophic Impulses","organismZ3R0","MaggieJ90","KimberBanfi","CascadingWalnuts",
            "Flash the Runner","ballislife96","dougiehalms","wolverine2011","NERevolution08","BarnardTHIRTEEN","NYUHeatherS","fooKazaam",
            "blastradius87","cliffordstephens","katieU92","jamiewinthrop21","claritabonita","Jezebel1997","Cornellian13","crimsonhockey96",
            "Cornelius Fudge","HPotterNoneTheRicher","HenryOP1012","HeyItsPenelope","brokenclavicle","johnbertrand88","czechdance92","philSUUUUX",
            "Kryptonite54","Pikachuuu","PlanA4JV","Belinda13","Dorchester99","EveIsHere22","KylieA33","AlexandraTheGreat","UberDriverTN",
            "Dosvedonna","AggieB2014","rainmanofNV","Elsa Vandy","TripChester14","RPIEngineer14","CDHockeyLegend","Jameson89","NeveForReal",
            "Kari3595","KerryS2002","ItsMeMolly","RainaIAm","LionWitchWardrobe","FireAndIcer98","Gymnasty23","Elle Woods!","DartagnanTheGood",
            "Yalie13","GoBigGreen14","CarnitasNo1","Cabriolet86","Sammmmmy","charlatte95","YoatMovement","dartmouth12","OCountyBeth","BrightonBiz",
            "StarL1ght Pr1nc355","Rainbow Dash---","BeyBlader08","Kelsey Jaffe","Sorkin5795","YouT00bJeff","Corsair Vince","Melissa the Wrista","Paola9299",
            "Enrico Boggi","Mike Denning CPA","Orphelia Smith","JamesPark389649","Kristin Jennnn","Kirsten Seeme","RosalynC3PO","FrankNtilinka",
            "JeffM91","LeoDCap","AlexiaDesigns","LilAnnie3298","SudburyLHS2012","Tuckahoe98","JanaCarlsen16","Plattsy72292","ScottsdaleRunner",
            "JudgeCarrie","CarolineBetz","Kinsey1996","TheStolenWalter","HankModena17","Daliah2001","BeyonceJay","AlixOfficial08","Xtina411",
            "SzenChen333","BryanKatz13","StanfordPines16","CindyLindyOSU","VictoriaB99","KarlR58","AsharNYWarrior","NidaDartmouth05","AfraidofWolf13",
            "BonnieJ13","BrittanyAAA15","Hannaaaaaaah","TJMixalot","CeejPicci","FJCarlsOfficial","Bev21Me","PortChesterGeoff","PeteyElectric","Arggggghhhh",
            "BabblingBrooklyn","CrustaceanPrintz","ZeldaDunkster","SoulWhopper","HorseGirl19","WriteSinsNotCassidy","DudewheresmyCarson","KallieMinx",
            "MissCleo89","CalamityJaneH","venustrick95","PuzzleProdigya7","Katn1ssEverd33n","Pocketrocket99","DomRevolution88","RadicalTutor","AutumnLeaves06",
            "AZStateGrrrl","CabriniDelcoGirl","HeyitsRaffy","whacked0","StevieJWinn","GarnetWages","Brunello1996","HarryTeesh18","GavinB99","PereBobby",
            "WhiteTacoma18","CharlesH07","Willhaus05","alfforpresident","AlexNidoran","MinecraftHenry","DrShankarIyer","PhilLiCPA","BryKaye","PickleballKing",
            "PickleballMaster75","KitchenLine08","DinKing96","SourPickleballer1","PickleballADED","FrankieBeans","WineDiane93","CarolineG03","DesPenn09",
            "Short Monkey", "Evil Alien", "Fast Pickle", "Curious Manse", "Trev Snore", "Greg B", "Vic K", "Check Yourself", "T Hunter", "FZ3ro Champ",
            "Paddle Clash", "Pandamonium Lover", "Neptune Rising"};
        private static readonly string[] fakeFirstName = {"Adam","adam","Alan","alan","Aaron","aaron","Acton","acton","Aces","aces","Brianne","brianne","Brian","brian","Bryan","bryan",
            "Barry","barry","Brett","brett","Bella","bella","British","Brit","brit","british","Brittany","brittany","britney","Britney","Bert","bert","Charlie",
            "Carl","carl","Charles","charles","Diego","diego","Dean","dean","Eli","eli","Frank","frank","Francesca","francesca","George","george","Gigi","gigi",
            "Henry","henry","Harry","harry","Ilsa","ilsa","Ilya","ilya","Ian","ian","Jerry","Joe","jerry","joe","Kevin","kevin","Liora","liora","Mike","mike",
            "Nick","nick","Luke","luke","Olivia","olivia","Oliver","oliver","Pete","pete","Peter","peter","Paul","paul","Priya","priya","Piper","piper","Rich","rich",
            "Randi","randi","Sam","sam","Theo","theo","Victor","victor","Wanda","wanda","Zeke","zeke","Edgar","edgar","Jose","jose","Julio","julio","Julia","julia",
            "Liam","liam","Noah","noah","Will","will","William","william","James","james","Benjamin","benjamin","Ben","ben","Elijah","elijah","Lucas","lucas","Mason",
            "mason","Logan","logan","Emma","emma","Ava","ava","Isabella","isabella","Sophia","sophia","Soph","soph","Isa","isa","Charlotte","charlotte","Mia","mia",
            "Amelia","amelia","Harper","harper","Evelyn","evelyn","Eve","eve","Alex","alex","Ethan","ethan","Jacob","jacob","Jake","jake","Michael","michael","Jackson",
            "jackson","Seb","seb","Sebastian","sebastian","Aiden","aiden","Matthew","matthew","Matt","matt","Abigail","abigail","Abby","abby","Em","em","Emily","emily",
            "Lizzie","lizzie","liz","Liz","Elizabeth","elizabeth","Mila","mila","Ella","ella","Avery","avery","Sofia","sofia","Camila","camila","Aria","aria","Scarlett",
            "scarlett","Mikey","mikey","Jim","jim","Jona", "jona","Jonah","jonah","joseph","Joseph","John","john","Jon","jon","Tony","tony","Don","don","Donald", "donald",
            "Donny","donny","Burt","burt","Andrew","andrew","Andy","andy","Woody","woody","Buzz","buzz","Rick","rick","Daryl","daryl","Carol","carol","Dale","dale","Judith",
            "judith","Judy","judy","Kev","kev","Steve","steve","Steven","steven","Stevie","stevie","Stephanie","stephanie","Steph","steph","Jackson","jackson","Bailey","bailey",
            "Shonda","shonda","Cecil","cecil","Mario","mario","Luigi","luigi","Latisha","latisha","Saquon","saquon","Janet","janet","Jane","jane","Justin","justin","Kara","kara",
            "Brad","brad","Bradley","bradley","Miguel","miguel","Jason","jason","Jayson","jayson","Jay","jay","Mark","mark","Angela","angela","Brenda","brenda","Carrie","carrie",
            "Chris","chris","Chad","chad","Hannah","hannah","Paula","paula"};
        private static readonly string[] fakeLastName = {"Smith","smith","Johnson","johnson","Williams","williams","Jones","jones","Brown","brown","Davis","davis","Miller","miller","Time","time",
            "Wilson","wilson","Moore","moore","Taylor","taylor","Anderson","anderson","Thomas","thomas","toms","Toms","Jackson","jackson","Jax","jacks","White","white",
            "Harris","harris","Li","li","Park","park","Kim","kim","Choi","choi","Bak","bak","Jeong","jeong","Yang","yang","Wang","wang","moon","Moon","Soccer","soccer",
            "Franklin","franklin","ball","Ball","Hernandez","hernandez","King","king","Lopez","lopez","Scott","scott","Turner","turner","Garcia","garcia","Martin","martin",
            "Clark","clark","Young","young","Morgan","morgan","Bell","bell","ishere","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","R","S","T","V","W","X",
            "Y","Z","Bailey","bailey","Ward","ward","Rogers","rogers","Evans","evans","Torres","torres","Gray","gray","blue","Blue","Brooks","brooks","kelly","Kelly",
            "Sanders","sanders","Price","price","James","james","Wood","wood","Perry","perry","Powell","powell","Diaz","diaz","Ford","ford","Sung","sings","Player",
            "Purcell","bieber","Bieber","Sanchez","sanchez","Collins","collins","Run","Love","love","YouTube","Official","official","twitch","Twitch","Herman","herman"};
        private static readonly string[] fakeNumber = {"0","1","2","3","4","5","6","7","8","9","99","12","13","14","15","16","17","18","19","20","2011","2012","2013","2014","2015","2000","10",
            "11","123","2001","2002","2003","2004","2005","2006","2007","2008","2009","2010","89","90","91","92","93","94","95","96","97","98","183","784","4784","3178",
            "9387","724","126","104","811","903","711","777","5496","816","491","50","00","01","02","03","04","05","06","07","08","09","1096","a","oo","OO","X","x","VvV",
            "clash","1203","82","83","84","85","86","87","88","909","114","621","0804","0102","!","?","A","B","y","dawg","dog","NY","CA","UK","LA","CN","NYC","ny","nyc",
            "NJ","TX","la","68","44","33","789","4295","211","311","411","1015","1126","1203","0602","708","623","202","203","204","205","206","221","222","223","224","225",
            "226","227","228","301","302","312","313","314","3.14","315","316","317","318","319","320","401","402","403","404","412","413","414","430","429","428","427",
            "527","526","525","625","714","812","813","814","815","816","817","818","819","820","905","906","915","919","921","922","923","925","926","107","108","109",
            "1011","1012","1021","1022","1023","111","112","113","117","118","1111","1112","1115","1117","1202","1207","1221","1224","1223","1225","505","606","707"};
        private static readonly string[] themeName = {"football","Football","hockey","Hockey","hoops","Hoops","Tennis","tennis","Baseball","baseball","Puck","puck","Slapper","Homerun","Dunk",
            "Gamer","gamer","Baller","baller","Runner","runner","Run","run","Switch","Unity","sniper","COD","Boston","NewYork","LosAngeles","Miami","Dallas","Detroit",
            "Cleveland","Ice","BSB","Nirvana","STP","BlackKeys","WhiteStripes","Godfather","Frozen","Garden","Draws","Blog","Stars","Cards","Poker","TV","FFB","FB","Cooks",
            "Brooklyn","Compton","Seattle","Vegas","Phoenix","Yoga","Cycling","Fish","Fly","Hikes","Polo","Surfs","Ski","Scuba","Camp","Blackjack","Slots","Chicago",
            "Philly","SanDiego","SanFran","Tampa","Pitt","pitt","Beijing","Delhi","Wuhan","Roma","Madrid","Paris","Soccer","soccer","Futbol","futbol","Bowl","Denver",
            "StLouis","Knicks","Lakers","Rangers","Kings","Stars","Mavs","Giants","Jets","Rams","Knights","Wings","Leafs","Devils","Sabres","Flyers","Sixers","Eagles",
            "Marlins","Panthers","GoCanes","RollTide","Mich","Cuse","Harvard","Yale","Princeton","Cornell","Brown","Dartmouth","Penn","Columbia","Stanford","MIT",
            "Bing","Caltech","Rice","Vandy","TheU","OSU","UM","Berkeley","UC","UT","UF","FIT","Parsons","Pratt","Tigers","Bulldogs","Zebras","MX","Dragons","STD",
            "Bengals","Cubs","Dodgers","Cards","Moscow","Cairo","Dubai","Berlin","Ajaccio","Munich","London","Okie","Newark","Charleston","Barca","Capetown"};
    }
}