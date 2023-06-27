using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehiclePage : Page
{
    [SerializeField] private Button b_pause;
    [SerializeField] private Button b_exitCar;

    [SerializeField] private GameObject kiri, kanan, gas, mundur , handBrake;

    private void Start()
    {
        b_exitCar.onClick.AddListener(() =>
        {
            GameManager.Instance.ChangeState(GameState.Game);
            GameSetting.Instance.ExitCar();
        });

        b_pause.onClick.AddListener(() =>
        {
            GameManager.Instance.ChangeState(GameState.Pause);
        });
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        GameSetting.Instance.OnInteractWithCar += Instance_OnInteractWithCar;
    }

    private void Instance_OnInteractWithCar(Cars car, bool inVehicle)
    {
        if(inVehicle == true)
        {
            car.GetCar().SetInputGameObject(kiri, kanan, gas, mundur , handBrake);
        }
    }
}
