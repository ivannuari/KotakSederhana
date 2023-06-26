using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HoverballPanel : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown_up;
    [SerializeField] private TMP_Dropdown dropdown_down;
    [SerializeField] private Slider slider_speed;

    [SerializeField] private TMP_Text label_slider;

    private void Start()
    {
        slider_speed.onValueChanged.AddListener((float value) =>
        {
            label_slider.text = $"{value.ToString("0")}";
        });

        label_slider.text = slider_speed.value.ToString("0");
    }
}
