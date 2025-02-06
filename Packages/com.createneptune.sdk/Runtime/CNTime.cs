using System;
using UnityEngine;

namespace CreateNeptune
{
    /// <summary>
    /// Singleton class that allows for the adjustment of the current time with an offset for testing purposes
    /// </summary>
    public class CNTime : Singleton<CNTime>
    {
        [SerializeField] private bool useAdjustedTimeInEditor = false;
        [SerializeField] private bool useAdjustedTimeInBuild = false;

        // The custom editor will display these fields, so they are hidden from the inspector
        [HideInInspector] public double weeks = 0;
        [HideInInspector] public double days = 0;
        [HideInInspector] public double hours = 0;
        [HideInInspector] public double minutes = 0;

        public double timeOffsetInSeconds
        {
            get
            {
                return (weeks * 604800) + (days * 86400) + (hours * 3600) + (minutes * 60);
            }
        }

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
