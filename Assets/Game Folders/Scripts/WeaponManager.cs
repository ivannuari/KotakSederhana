using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    [SerializeField] private Transform nozzle;
    [SerializeField] private WeaponType currentWeapon = WeaponType.Weld;

    [SerializeField] private GameObject[] weapons;

    private PlayerSpawnObject spawner;

    public delegate void ToolsChangeDelegate(WeaponType newType);
    public event ToolsChangeDelegate OnToolsChange;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        GameSetting.Instance.OnChangeWeapon += Instance_OnChangeWeapon;

        spawner = GetComponent<PlayerSpawnObject>();
    }


    private void OnDisable()
    {
        GameSetting.Instance.OnChangeWeapon -= Instance_OnChangeWeapon;
    }

    public void SetWeapon(WeaponType newType)
    {
        currentWeapon = newType;
        OnToolsChange?.Invoke(newType);
    }

    public void CheckWeapon()
    {
        OnToolsChange?.Invoke(currentWeapon);
    }

    public WeaponType GetCurrentWeapon()
    {
        return currentWeapon;
    }

    private void Instance_OnChangeWeapon(bool isMainWeapon)
    {
        weapons[0].SetActive(isMainWeapon);
        weapons[1].SetActive(!isMainWeapon);
    }
}


public enum WeaponType
{
    Weld,
    Remove,
    Duplicate,
    Thruster,
    Hoverball,
    Dynamite
}
