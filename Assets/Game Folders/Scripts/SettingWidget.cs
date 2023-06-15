using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingWidget : Widget
{
    [SerializeField] private TMP_Dropdown dropdown_quality;
    [SerializeField] private Slider slider_sensitivity;
    [SerializeField] private TMP_Text label_slider;

    [SerializeField] private Button b_default;
    [SerializeField] private Button b_back;

    private void Start()
    {
        slider_sensitivity.onValueChanged.AddListener((float val) =>
        {
            float temp = val * 100f;
            label_slider.text = temp.ToString("0");
        });

        b_default.onClick.AddListener(() =>
        {

        });

        b_back.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Pause));
    }
}