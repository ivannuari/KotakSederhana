using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager Instance;

    [SerializeField] private Transform nozzle;
    [SerializeField , Range(50f , 150f)] private float maxDistance = 100f;
    [SerializeField] private LayerMask layerCharacter;
    [SerializeField] private WeaponType currentWeapon = WeaponType.Weld;

    [SerializeField] private bool isTrigger = false;

    [SerializeField] private GameObject[] weapons;

    private PlayerSpawnObject spawner;

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
        GameSetting.Instance.OnShootAction += Instance_OnShootAction;

        spawner = GetComponent<PlayerSpawnObject>();
    }


    private void OnDisable()
    {
        GameSetting.Instance.OnChangeWeapon -= Instance_OnChangeWeapon;
        GameSetting.Instance.OnShootAction -= Instance_OnShootAction;
    }

    public void SetWeapon(WeaponType newType)
    {
        currentWeapon = newType;
        GameSetting.Instance.ChangeWeapon(false);
    }

    public WeaponType GetCurrentWeapon()
    {
        return currentWeapon;
    }

    private void Instance_OnShootAction(bool isShoot)
    {
        isTrigger = isShoot;
    }

    private void Instance_OnChangeWeapon(bool isMainWeapon)
    {
        weapons[0].SetActive(isMainWeapon);
        weapons[1].SetActive(!isMainWeapon);
    }



    private void FixedUpdate()
    {
        /*RaycastHit hit;
        bool isHit = Physics.Raycast(nozzle.position, nozzle.TransformDirection(nozzle.forward) , out hit, maxDistance , layerCharacter);
        
        if (isHit && isTrigger)
        {
            if (weapons[0].activeInHierarchy)
            {
                hit.transform.position = spawner.GetSpawnPosition().position;
            }
            else
            {
                switch (currentWeapon)
                {
                    case WeaponType.Weld:
                        break;
                    case WeaponType.Remove:
                        Destroy(hit.collider.gameObject);
                        break;
                    case WeaponType.Duplicate:
                        Instantiate(hit.collider.gameObject, spawner.GetSpawnPosition().position, Quaternion.identity);
                        break;
                    case WeaponType.Thruster:
                        break;
                    case WeaponType.Hoverball:
                        break;
                    case WeaponType.Dynamite:
                        break;
                }
            }
        }*/
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
