using System.Collections.Generic;
using UnityEngine;

namespace CreateNeptune
{
    public static class CNWebUtils
    {
        private static readonly HashSet<string> IgnoredErrors = new HashSet<string>
        {
            "Host could not be resolved",
            // Add additional common error messages here to be ignored from logging
        };

		/// <summary>
		/// Logs web request errors, filtering out specified common errors. 
		/// Optionally logs ignored errors based on a parameter.
		/// </summary>
		/// <param name="error">The error message to be logged.</param>
		/// <param name="logIgnoredErrors">If true, logs errors that are normally ignored due to being common and non-critical. Defaults to false.</param>
        public static void LogWebRequestError(string error, bool logIgnoredErrors = false)
        {
            if (!IgnoredErrors.Contains(error))
            {
                Debug.LogError($"Web Request Error: {error}");
            }
            else if (logIgnoredErrors)
            {
                Debug.Log($"Ignored Web Request Error: {error}");
            }
        }
    }
}
