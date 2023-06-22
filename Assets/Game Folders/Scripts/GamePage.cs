using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePage : Page
{
    [SerializeField] private Button b_pause;
    [SerializeField] private Button b_switch;
    [SerializeField] private Button b_menu;
    [SerializeField] private Button b_build;
    [SerializeField] private Button b_delete;

    [SerializeField] private GameObject numberWidget;
    private bool isNumberWidgetActive = false;
    private bool isMainWeapon = true;

    private void Start()
    {
        b_pause.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Pause));
        b_build.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.EditMode));

        b_menu.onClick.AddListener(() =>
        {
            numberWidget.SetActive(!isNumberWidgetActive);
            isNumberWidgetActive = !isNumberWidgetActive;
        });

        b_switch.onClick.AddListener(() =>
        {
            GameSetting.Instance.ChangeWeapon(!isMainWeapon);
            isMainWeapon = !isMainWeapon;
        });
    }
}
