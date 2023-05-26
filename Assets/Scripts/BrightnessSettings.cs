using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float sliderValue;
    [SerializeField] private Image panelBrightness;

    private void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("brightness", 0f);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderValue);
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("brightness", sliderValue);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderValue);
    }
}
