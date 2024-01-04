using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestFlashAnimation : EaseFunctionTest
{
    public float flashInterval = 0.5f;
    public Color flashColor = Color.white;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, CNAction.FlashAnimation(gameObject, flashInterval, animationTime, flashColor, CNEase.GetEasingFunc(easeType)));
    }
}
