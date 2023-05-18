using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QualityOptions : MonoBehaviour
{
    [SerializeField] TMP_Dropdown dropdown;
    [SerializeField] int quality;
    // Start is called before the first frame update
    void Start()
    {
        quality = PlayerPrefs.GetInt("qualityNumber",3);
        dropdown.value = quality;
        ApplyQuality();
    }
    
    public void ApplyQuality()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("qualityNumber", dropdown.value);
        quality = dropdown.value;
    }
}
