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

    private float defaultSensitivity = 0.05f;

    private void OnEnable()
    {
        SetSensitivity(GameSetting.Instance.GetSensitivity());
    }

    private void Start()
    {

        slider_sensitivity.onValueChanged.AddListener((float val) =>
        {
            SetSensitivity(val);
        });

        b_default.onClick.AddListener(() =>
        {
            SetSensitivity(defaultSensitivity);
        });

        b_back.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Pause));
    }

    private void SetSensitivity(float value)
    {
        label_slider.text = value.ToString("F2");
        GameSetting.Instance.SetPlayerSensitivity(value);
    }
}