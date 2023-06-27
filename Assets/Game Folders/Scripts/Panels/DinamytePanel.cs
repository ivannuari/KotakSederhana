using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DinamytePanel : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown_dinamyte;
    [SerializeField] private Slider slider_timer;

    [SerializeField] private TMP_Text label_slider;

    private void Start()
    {
        slider_timer.onValueChanged.AddListener((float value) =>
        {
            label_slider.text = $"{value.ToString("0")}";
            GameSetting.Instance.activeSliderTime = value;
        });

        label_slider.text = slider_timer.value.ToString("0");

        dropdown_dinamyte.onValueChanged.AddListener((int n) => GameSetting.Instance.SetFiresNumberActive(n));
    }
}
