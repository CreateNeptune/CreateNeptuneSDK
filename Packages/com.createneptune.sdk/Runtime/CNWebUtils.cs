using System.Collections.Generic;
using UnityEngine;

namespace CreateNeptune
{
    public static class CNWebUtils
    {
        private static readonly HashSet<string> IgnoredErrors = new HashSet<string>
        {
			"Cannot resolve destination host",
			"SSL CA certificate error",
			"Unable to complete SSL connection",
			"Unknown error",
			"Cannot connect to destination host",
			"Request timeout",
            // Add additional common error messages here to be ignored from logging
        };

		/// <summary>
		/// Logs web request errors, filtering out specified common errors. 
		/// Optionally logs ignored errors based on a parameter. Allows for additional context to be included in the log message.
		/// </summary>
		/// <param name="error">The error message to be logged.</param>
		/// <param name="logIgnoredErrors">If true, logs errors that are normally ignored due to being common and non-critical. Defaults to false.</param>
		/// <param name="context">Optional context information to be included in the log message. Defaults to null.</param>
        public static void LogWebRequestError(string error, bool logIgnoredErrors = false, string context = null)
        {
			string logMessage = context != null ? $"{error}. Context: {context}" : error;
			
            if (!IgnoredErrors.Contains(error))
            {
                Debug.LogError($"Web Request Error: {logMessage}");
            }
            else if (logIgnoredErrors)
            {
                Debug.Log($"Ignored Web Request Error: {logMessage}");
            }
        }
    }
}
