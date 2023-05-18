using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSettings : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] float sliderValue;
    [SerializeField] Image panelBrightness;
    // Start is called before the first frame update
    void Start()
    {
        sliderValue = PlayerPrefs.GetFloat("brightness", 0.5f);

        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSlider(float value)
    {
        sliderValue = value;
        PlayerPrefs.SetFloat("brightness", sliderValue);
        panelBrightness.color = new Color(panelBrightness.color.r, panelBrightness.color.g, panelBrightness.color.b, sliderValue);
    }
}
