using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetting : MonoBehaviour
{
    public static GameSetting Instance;

    public delegate void CreatePropDelegate(ModelType tipe , int index);
    public event CreatePropDelegate OnCreateProp;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
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


[System.Serializable]
public class modelProps
{
    public ModelType tipe;
    public GameObject prefab;
}
