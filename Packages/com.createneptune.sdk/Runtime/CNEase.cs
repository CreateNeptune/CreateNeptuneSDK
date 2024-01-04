// Create Neptune SDK (c) 2021 Create Neptune LLC.
// All rights reserved.

using System.Collections.Generic;
using UnityEngine;

namespace CreateNeptune
{
    /// <summary>
    /// Contains all of the common easing functions, as well as an enum to make them accessible in the inspector.
    /// See this chart for a visualization of each function: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
    /// </summary>
    public static class CNEase
    {
        /// <summary>
        /// An enum with a value corresponding to every available easing function.
        /// The main use-case is to make easing type selectable in the inspector.
        /// </summary>
        public enum EaseType
        {
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
            InOutBounce,
        }

        /// <summary>
        /// Used internally to match EaseType enums with their corresponding functions.
        /// </summary>
        private static readonly Dictionary<EaseType, EasingFunc> easingFuncDictionary = new()
        {
            // New naming scheme
            { EaseType.Linear, Linear },
            { EaseType.InSine, InSine },
            { EaseType.OutSine, OutSine },
            { EaseType.InOutSine, InOutSine },
            { EaseType.InQuad, InQuad },
            { EaseType.OutQuad, OutQuad },
            { EaseType.InOutQuad, InOutQuad },
            { EaseType.InCubic, InCubic },
            { EaseType.OutCubic, OutCubic },
            { EaseType.InOutCubic, InOutCubic },
            { EaseType.InQuart, InQuart },
            { EaseType.OutQuart, OutQuart },
            { EaseType.InOutQuart, InOutQuart },
            { EaseType.InQuint, InQuint },
            { EaseType.OutQuint, OutQuint },
            { EaseType.InOutQuint, InOutQuint },
            { EaseType.InExpo, InExpo },
            { EaseType.OutExpo, OutExpo },
            { EaseType.InOutExpo, InOutExpo },
            { EaseType.InCirc, InCirc },
            { EaseType.OutCirc, OutCirc },
            { EaseType.InOutCirc, InOutCirc },
            { EaseType.InBack, InBack },
            { EaseType.OutBack, OutBack },
            { EaseType.InOutBack, InOutBack },
            { EaseType.InElastic, InElastic },
            { EaseType.OutElastic, OutElastic },
            { EaseType.InOutElastic, InOutElastic },
            { EaseType.InBounce, InBounce },
            { EaseType.OutBounce, OutBounce },
            { EaseType.InOutBounce, InOutBounce },
        };

        /// <summary>
        /// A function that takes a value between 0 and 1 and returns an eased time
        /// </summary>
        /// <param name="x">A value between 0 and 1</param>
        /// <returns>The eased timing of x</returns>
        public delegate float EasingFunc(float x);

        /// <summary>
        /// Get an easing function using the EaseType enum. <br></br>
        /// Use with the EaseType enum if you want to make the easing function selectable in the inspector.
        /// </summary>
        /// <param name="easeType"></param>
        /// <returns></returns>
        public static EasingFunc GetEasingFunc(EaseType easeType)
        {
            return easingFuncDictionary[easeType];
        }

        /// <summary>
        /// Gets the eased timing for the provided value using the specified ease type. <br></br>
        /// Use with the EaseType enum if you want to make the easing function selectable in the inspector.
        /// </summary>
        /// <param name="easeType">Th easing function to use</param>
        /// <param name="x">Normalized time value (from 0 to 1)</param>
        /// <returns>The eased timing of x</returns>
        public static float GetEasedTime(EaseType easeType, float x)
        {
            return easingFuncDictionary[easeType](x);
        }

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
        /// The most useful function of all time (this is only really here to keep consistent syntax)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float Linear(float x)
        {
            return x;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InSine(float x)
        {
            return 1 - Mathf.Cos(x * Mathf.PI / 2);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutSine(float x)
        {
            return Mathf.Sin(x * Mathf.PI / 2);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutSine(float x)
        {
            return -(Mathf.Cos(Mathf.PI * x) - 1) / 2;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InQuad(float x)
        {
            return x * x;
        }
        
        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutQuad(float x)
        {
            return 1 - (1 - x) * (1 - x);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutQuad(float x)
        {
            return x < 0.5 ? 2 * x * x : 1 - Mathf.Pow(-2 * x + 2, 2) / 2;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InCubic(float x)
        {
            // Note: multiplication is faster than Mathf.Pow here
            return x * x * x;        
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutCubic(float x)
        {
            return 1 - Mathf.Pow(1 - x, 3);    
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutCubic(float x)
        {
            // Note: multiplication is faster than Mathf.Pow here
            return x < 0.5 ? 4 * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 3) / 2;    
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InQuart(float x)
        {
            // Note: multiplication is faster than Mathf.Pow here
            return x * x * x * x;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutQuart(float x)
        {
            return 1 - Mathf.Pow(1 - x, 4);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutQuart(float x)
        {
            // Note: multiplication is faster than Mathf.Pow here
            return x < 0.5 ? 8 * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InQuint(float x)
        {
            // Note: multiplication is faster than Mathf.Pow here
            return x * x * x * x * x;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutQuint(float x)
        {
            return 1 - Mathf.Pow(1 - x, 5);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutQuint(float x)
        {
            // Note: multiplication is faster than Mathf.Pow here
            return x < 0.5 ? 16 * x * x * x * x * x : 1 - Mathf.Pow(-2 * x + 2, 5) / 2;
        }   

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InExpo(float x)
        {
            return x == 0 ? 0 : Mathf.Pow(2, 10 * x - 10);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutExpo(float x)
        {
            return x == 1 ? 1 : 1 - Mathf.Pow(2, -10 * x);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutExpo(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : x < 0.5 ? Mathf.Pow(2, 20 * x - 10) / 2
                : (2 - Mathf.Pow(2, -20 * x + 10)) / 2;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InCirc(float x)
        {
            x = Mathf.Clamp01(x);
            return 1 - Mathf.Sqrt(1 - Mathf.Pow(x, 2));
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutCirc(float x)
        {
            x = Mathf.Clamp01(x);
            return Mathf.Sqrt(1 - Mathf.Pow(x - 1, 2));
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutCirc(float x)
        {
            x = Mathf.Clamp01(x);
            return x < 0.5
                ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * x, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * x + 2, 2)) + 1) / 2;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InBack(float x)
        {
            return c3 * x * x * x - c1 * x * x;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutBack(float x)
        {
            return 1 + c3 * Mathf.Pow(x - 1, 3) + c1 * Mathf.Pow(x - 1, 2);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutBack(float x)
        {
            return x < 0.5
                ? Mathf.Pow(2 * x, 2) * ((c2 + 1) * 2 * x - c2) / 2
                : (Mathf.Pow(2 * x - 2, 2) * ((c2 + 1) * (x * 2 - 2) + c2) + 2) / 2;
        }    
        
        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InElastic(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : -Mathf.Pow(2, 10 * x - 10) * Mathf.Sin((x * 10 - 10.75f) * c4);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutElastic(float x)
        {
            return x == 0
                ? 0
                : x == 1
                ? 1
                : Mathf.Pow(2, -10 * x) * Mathf.Sin((x * 10 - 0.75f) * c4) + 1;
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutElastic(float x)
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
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InBounce(float x)
        {
            return 1 - OutBounce(1 - x);
        }

        /// <summary>
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float OutBounce(float x)
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
        /// See visualization on this chart: https://github.com/CreateNeptune/CreateNeptuneSDK/blob/main/easings.png
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float InOutBounce(float x)
        {
            return x < 0.5
                ? (1 - OutBounce(1 - 2 * x)) / 2
                : (1 + OutBounce(2 * x - 1)) / 2;
        }
#endregion
    }
}
