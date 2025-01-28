using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateNeptune
{
    public class CNTime : Singleton<CNTime>
    {
        [SerializeField] private bool useAdjustedTimeInEditor = false;
        [SerializeField] private bool useAdjustedTimeInBuild = false;
        public double timeOffsetInSeconds = 0;

        public static DateTime Now
        {
            get
            {
                // If the instance exists and the adjusted time is enabled in the editor or build, return the current time with the offset added
                // This also means that if the instance doesn't exist for whatever reason, the current time will be returned
                if (Instance != null && (Application.isEditor ? Instance.useAdjustedTimeInEditor : Instance.useAdjustedTimeInBuild))
                {
                    return DateTime.Now.AddSeconds(Instance.timeOffsetInSeconds);
                }
                else 
                {
                    return DateTime.Now;
                }
            }
        }

        public static DateTime UtcNow
        {
            get
            {
                // If the instance exists and the adjusted time is enabled in the editor or build, return the current time with the offset added
                // This also means that if the instance doesn't exist for whatever reason, the current time will be returned
                if (Instance != null && (Application.isEditor ? Instance.useAdjustedTimeInEditor : Instance.useAdjustedTimeInBuild))
                {
                    return DateTime.UtcNow.AddSeconds(Instance.timeOffsetInSeconds);
                }
                else 
                {
                    return DateTime.UtcNow;
                }
            }
        }

        public static DateTime Today
        {
            get
            {
                // If the instance exists and the adjusted time is enabled in the editor or build, return the current time with the offset added
                // This also means that if the instance doesn't exist for whatever reason, the current time will be returned
                if (Instance != null && (Application.isEditor ? Instance.useAdjustedTimeInEditor : Instance.useAdjustedTimeInBuild))
                {
                    return DateTime.Now.AddSeconds(Instance.timeOffsetInSeconds).Date;
                }
                else 
                {
                    return DateTime.Today;
                }
            }
        }
    }
}
