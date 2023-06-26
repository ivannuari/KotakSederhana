using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionPanel : MonoBehaviour
{
    [SerializeField] private Button b_player;

    [SerializeField] private Slider slider_speed;
    [SerializeField] private Slider slider_jump;
    [SerializeField] private Slider slider_flySpeed;
    [SerializeField] private Toggle toogle_fly;

    [SerializeField] private TMP_Text label_speed;
    [SerializeField] private TMP_Text label_jump;
    [SerializeField] private TMP_Text label_flySpeed;

    private void OnEnable()
    {
        b_player.Select();
    }

    private void Start()
    {
        slider_speed.value = GameSetting.Instance.GetPlayerSpeed();
        slider_jump.value = GameSetting.Instance.GetPlayerJump();

        SetSpeed(slider_speed.value);
        SetJump(slider_jump.value);
        SetFlyJump(slider_flySpeed.value);

        slider_speed.onValueChanged.AddListener((float v) =>
        {
            GameSetting.Instance.SetPlayerSpeed(v);
            SetSpeed(v);
        });

        slider_jump.onValueChanged.AddListener((float v) =>
        {
            GameSetting.Instance.SetPlayerJump(v);
            SetJump(v);
        });

        slider_flySpeed.onValueChanged.AddListener((float v) =>
        {
            SetFlyJump(v);
        });
    }

    private void SetSpeed(float value)
    {
        float tempSpeed =  value * 100f;
        label_speed.text = tempSpeed.ToString("0");
    }

    private void SetJump(float value)
    {
        float tempJump = value * 100f;
        label_jump.text = tempJump.ToString("0");
    }

    private void SetFlyJump(float value)
    {
        float tempFlySpeed = value * 100f;
        label_flySpeed.text = tempFlySpeed.ToString("0");
    }
}
