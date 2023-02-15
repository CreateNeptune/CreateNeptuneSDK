using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HueTest : MonoBehaviour
{
	[SerializeField] private Image uiImage;
	[SerializeField] private float animTime;

	[SerializeField] private Button blueButton;
	[SerializeField] private Button greenButton;
	[SerializeField] private Button redButton;
	
	[SerializeField] private Color blue;
	[SerializeField] private Color green;
	[SerializeField] private Color red;
	

    private void FadeHue(Color colorToSwitchTo)
	{
		Color.RGBToHSV(uiImage.color, out float startHue, out float sat, out float val);
		Color.RGBToHSV(colorToSwitchTo, out float endHue, out _, out _);

		StartCoroutine(CreateNeptune.MPAction.ColorObjectHue(uiImage.gameObject, animTime, startHue, endHue, sat, val, false, false, true));
	}

	public void Start()
	{
		blueButton.onClick.AddListener(TurnBlue);
		greenButton.onClick.AddListener(TurnGreen);
		redButton.onClick.AddListener(TurnRed);
	}

	private void TurnBlue()
	{
		FadeHue(blue);
	}

	private void TurnGreen()
	{
		FadeHue(green);
	}

	private void TurnRed()
	{
		FadeHue(red);
	}

	
}
