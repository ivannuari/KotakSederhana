using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThrusterPanel : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown_push;
    [SerializeField] private TMP_Dropdown dropdown_pull;
    [SerializeField] private Slider slider_force;

    [SerializeField] private TMP_Text label_slider;

    private void Start()
    {
        slider_force.onValueChanged.AddListener((float value) =>
        {
            label_slider.text = $"{value.ToString("0")}";
        });

        label_slider.text = slider_force.value.ToString("0");
    }
}
