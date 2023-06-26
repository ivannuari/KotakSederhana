using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GamePage : Page
{
    [SerializeField] private Button b_pause;
    [SerializeField] private Button b_switch;
    [SerializeField] private Button b_menu;
    [SerializeField] private Button b_build;
    [SerializeField] private Button b_delete;
    [SerializeField] private Button b_shoot;
    [SerializeField] private Button b_enterCar;

    [SerializeField] private GameObject numberWidget;
    [SerializeField] private GameObject panel_weld;

    private bool isNumberWidgetActive = false;
    private bool isMainWeapon = true;
    private bool isShoot = false;

    private void Start()
    {
        GameSetting.Instance.OnChangeWeapon += Instance_OnChangeWeapon;
        GameSetting.Instance.OnInRangeOfCar += Instance_OnInRangeOfCar;

        b_pause.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Pause));
        b_build.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.EditMode));
        b_enterCar.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Vehicle));
        b_delete.onClick.AddListener(GameSetting.Instance.DeleteSpawnObject);

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

        b_shoot.onClick.AddListener(() =>
        {
            GameSetting.Instance.ShootWeapon(isShoot);
            isShoot = !isShoot;
        });
    }


    protected override void OnEnable()
    {
        base.OnEnable();

        if(GameSetting.Instance != null)
        {
            GameSetting.Instance.OnChangeWeapon += Instance_OnChangeWeapon;
            GameSetting.Instance.OnInRangeOfCar += Instance_OnInRangeOfCar;
        }
    }

    private void OnDisable()
    {
        GameSetting.Instance.OnChangeWeapon -= Instance_OnChangeWeapon;
        GameSetting.Instance.OnInRangeOfCar -= Instance_OnInRangeOfCar;
    }

    private void Instance_OnInRangeOfCar(bool inRange)
    {
        b_enterCar.gameObject.SetActive(inRange);
    }

    private void Instance_OnChangeWeapon(bool isMainWeapon)
    {
        panel_weld.SetActive(!isMainWeapon);
        TMP_Text label = panel_weld.GetComponentInChildren<TMP_Text>();
        label.text = WeaponManager.Instance.GetCurrentWeapon().ToString();
    }

    public void ShootHold(bool press)
    {
        GameSetting.Instance.ShootWeapon(press);
    }
}
