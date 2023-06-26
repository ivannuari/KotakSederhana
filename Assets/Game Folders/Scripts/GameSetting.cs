using StarterAssets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static GameSetting Instance;

    [System.Serializable]
    public class LevelPlaneContainer
    {
        public PlaneType tipe;
        public Material mat;
    }

    [SerializeField] private MeshRenderer plane;
    [SerializeField] private LevelPlaneContainer[] allPlanes;

    [SerializeField] private FirstPersonController fps;

    public List<GameObject> objectSpawns = new List<GameObject>();

    public delegate void CreatePropDelegate(ModelType tipe , int index);
    public event CreatePropDelegate OnCreateProp;

    public delegate void ChangeWeaponDelegate(bool isMainWeapon);
    public event ChangeWeaponDelegate OnChangeWeapon;

    public delegate void CheckRangeOfCar(bool inRange);
    public event CheckRangeOfCar OnInRangeOfCar;

    public void SetRangeOfCar(bool inRange)
    {
        OnInRangeOfCar?.Invoke(inRange);
    }

    public delegate void OnShootDelegate(bool isShoot);
    public event OnShootDelegate OnShootAction;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        SetLevelPlane();
    }

    private void SetLevelPlane()
    {
        switch (GameManager.Instance.GetLevelPlane())
        {
            case PlaneType.Grass:
                plane.material = allPlanes[0].mat;
                break;
            case PlaneType.Sand:
                plane.material = allPlanes[1].mat;
                break;
            case PlaneType.Stone:
                plane.material = allPlanes[2].mat;
                break;
        }
    }

    public void ChangeWeapon(bool isMain)
    {
        OnChangeWeapon?.Invoke(isMain);
    }

    public void ShootWeapon(bool isShoot)
    {
        OnShootAction?.Invoke(isShoot);
    }

    public void CreateProp(ModelType tipe , int index)
    {
        OnCreateProp?.Invoke(tipe, index);
    }

    public void AddSpawnObject(GameObject obj)
    {
        objectSpawns.Add(obj);
    }

    public void DeleteSpawnObject()
    {
        if (objectSpawns.Count > 0)
        {
            Destroy(objectSpawns[objectSpawns.Count - 1]);
            objectSpawns.RemoveAt(objectSpawns.Count - 1);
        }
    }

    public void SetPlayerSpeed(float newSpeed)
    {
        fps.MoveSpeed = newSpeed;
    }

    public void SetPlayerJump(float newJump)
    {
        fps.JumpHeight = newJump;
    }

    public float GetPlayerSpeed() { return fps.MoveSpeed; }
    public float GetPlayerJump() { return fps.JumpHeight; }

}



public enum ModelType
{
    Furniture,
    Street,
    Cartoon,
    Building,
    People,
    Primitives,
    Road,
    Cars,
    Others,
    Ragdoll
}

public enum PlaneType
{
    Grass,
    Sand,
    Stone
}


[System.Serializable]
public class modelProps
{
    public ModelType tipe;
    public GameObject prefab;
}

