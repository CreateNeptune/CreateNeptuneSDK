using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestColorObject : EaseFunctionTest
{
    public Color targetColor = Color.white;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, CNAction.ColorObject(gameObject, animationTime, targetColor, CNEase.GetEasingFunc(easeType)));
    }
}
