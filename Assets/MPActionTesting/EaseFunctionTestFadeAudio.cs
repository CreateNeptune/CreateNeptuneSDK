using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateNeptune;

public class EaseFunctionTestFadeAudio : EaseFunctionTest
{
    public float targetVolume;

    public override void BeginTween()
    {
        CNExtensions.SafeStartCoroutine(this, ref tweenRoutine, MPAction.FadeAudioSource(GetComponent<AudioSource>(), animationTime, targetVolume, easeType));
    }
}
