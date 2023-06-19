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

    public delegate void CreatePropDelegate(ModelType tipe , int index);
    public event CreatePropDelegate OnCreateProp;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }

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

    public void CreateProp(ModelType tipe , int index)
    {
        OnCreateProp?.Invoke(tipe, index);
    }
}



public enum ModelType
{
    Furniture,
    Street,
    Cartoon,
    Building,
    People,
    Primitives,
    Road
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

