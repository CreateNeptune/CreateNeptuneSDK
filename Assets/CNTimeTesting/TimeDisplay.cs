using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Basic test class to display the CNTime
/// </summary>
public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private Text[] texts;

    private void Update()
    {
        texts[0].text = "Now: " + CreateNeptune.CNTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
        texts[1].text = "UtcNow: " + CreateNeptune.CNTime.UtcNow.ToString("MM/dd/yyyy HH:mm:ss");
        texts[2].text = "Today: " + CreateNeptune.CNTime.Today.ToString("MM/dd/yyyy");
    }
}
