using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDua : Gun
{
    [SerializeField] private WeaponType currentWeapon = WeaponType.Weld;
    [SerializeField] private Transform ujung;

    [SerializeField] private GameObject dinamyte;

    protected override void Start()
    {
        base.Start();
        
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        WeaponManager.Instance.OnToolsChange += Instance_OnToolsChange;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        WeaponManager.Instance.OnToolsChange -= Instance_OnToolsChange;
    }

    private void Instance_OnToolsChange(WeaponType newType)
    {
        currentWeapon = newType;
    }

    public override void Shoot(bool isShoot)
    {
        RaycastHit hit;
        isOnShoot = isShoot;

        if (isShoot)
        {
            if (Physics.Raycast(cam.position, cam.forward, out hit, gunRange, propLayer))
            {
                OnShootObject(hit.transform.gameObject);
            }
        }

        bool shoot = isShoot;
        if(shoot)
        {
            switch (currentWeapon)
            {
                case WeaponType.Thruster:
                    break;
                case WeaponType.Hoverball:
                    break;
                case WeaponType.Dynamite:
                    GameObject d = Instantiate(dinamyte, ujung.position, Quaternion.identity);
                    d.GetComponent<Dinamyte>().firesNumber = GameSetting.Instance.activeFiresNumber + 1;
                    d.GetComponent<Dinamyte>().sliderMod = GameSetting.Instance.activeSliderTime;
                    shoot = false;
                    break;
            }
        }
    }

    public override void OnShootObject(GameObject obj)
    {
        if (gameObject.activeInHierarchy)
        {
            Debug.Log(currentWeapon.ToString());
            switch (currentWeapon)
            {
                case WeaponType.Weld:
                    break;
                case WeaponType.Remove:
                    GameSetting.Instance.DeleteSpawnObject(obj);
                    break;
                case WeaponType.Duplicate:
                    GameSetting.Instance.Duplicate(obj);
                    break;
            }
        }
    }
}
