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
    [SerializeField] private Transform spawner;
    [SerializeField] private Cars currentCar;

    public List<GameObject> objectSpawns = new List<GameObject>();
    public int activeFiresNumber = 0;
    public float activeSliderTime = 0f;

    public delegate void CreatePropDelegate(ModelType tipe , int index);
    public event CreatePropDelegate OnCreateProp;

    public delegate void ChangeWeaponDelegate(bool isMainWeapon);
    public event ChangeWeaponDelegate OnChangeWeapon;

    public delegate void CheckRangeOfCar(bool inRange);
    public event CheckRangeOfCar OnInRangeOfCar;

    public delegate void InteractCarDelegate(Cars  car , bool inVehicle);
    public event InteractCarDelegate OnInteractWithCar;

    public delegate void OnShootDelegate(bool isShoot);
    public event OnShootDelegate OnShootAction;

    public delegate void FiresNumberDelegate(int n);
    public event FiresNumberDelegate OnFiresNumber;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

        OnInteractWithCar += GameSetting_OnInteractWithCar;
    }

    private void OnDisable()
    {
        OnInteractWithCar -= GameSetting_OnInteractWithCar;
    }

    private void GameSetting_OnInteractWithCar(Cars car , bool inVehicle)
    {
        currentCar = car;
        fps.gameObject.SetActive(!inVehicle);
        car.ActivateCar();
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

    public void FiresButton(int nomor)
    {
        OnFiresNumber?.Invoke(nomor);
    }

    public void SetFiresNumberActive(int n)
    {
        activeFiresNumber = n;
    }

    public void SetRangeOfCar(bool inRange)
    {
        OnInRangeOfCar?.Invoke(inRange);
    }

    public void EnterCar(Cars cars, bool v)
    {
        OnInteractWithCar?.Invoke(cars, v);
    }

    public void ExitCar()
    {
        OnInteractWithCar?.Invoke(currentCar ,false);
        currentCar.DeactivateCar();
    }

    public void ChangeWeapon(bool isMain)
    {
        OnChangeWeapon?.Invoke(isMain);
    }

    public void ShootWeapon(bool isShoot)
    {
        OnShootAction?.Invoke(isShoot);
    }
    public void SetPlayerSensitivity(float value)
    {
        fps.RotationSpeed = value;
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

    public void DeleteSpawnObject(GameObject obj)
    {
        Destroy(obj);
        
    }

    public void Duplicate(GameObject obj)
    {
        GameObject temp = Instantiate(obj, spawner.position , Quaternion.identity);
        AddSpawnObject(temp);
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
    public float GetSensitivity() { return fps.RotationSpeed; }

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

