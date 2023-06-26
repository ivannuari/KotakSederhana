using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnObject : MonoBehaviour
{
    [SerializeField] private modelProps[] allProps;
    [SerializeField] private Transform spawner;

    private void Start()
    {
        GameSetting.Instance.OnCreateProp += Instance_OnCreateProp;   
    }

    private void OnDisable()
    {
        GameSetting.Instance.OnCreateProp -= Instance_OnCreateProp;     
    }

    public Transform GetSpawnPosition()
    {
        return spawner;
    }

    private void Instance_OnCreateProp(ModelType tipe, int index)
    {
        modelProps tempProp = Array.Find(allProps, p => p.tipe == tipe);
        GameObject g = Instantiate(tempProp.prefab, spawner.position, Quaternion.identity);

        GameSetting.Instance.AddSpawnObject(g);

        g.GetComponent<Props>().SetIndex(index);

        Vector3 newPos = transform.position;
        newPos.x = 0f;
        newPos.z = 0f;
        g.transform.LookAt(newPos);
    }
}
