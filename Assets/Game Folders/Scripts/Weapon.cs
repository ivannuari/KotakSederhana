using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform ujung;

    [SerializeField] private bool isShoot , onTrack;
    private GameObject objectOnTrack;

    private void Start()
    {
        GameSetting.Instance.OnShootAction += Instance_OnShootAction;
    }

    private void OnDisable()
    {
        GameSetting.Instance.OnShootAction -= Instance_OnShootAction;
    }

    private void Instance_OnShootAction(bool isOn)
    {
        isShoot = isOn;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Props"))
        {
            Use(other.gameObject);
        }
    }

    private void Update()
    {
        if(isShoot && onTrack)
        {
            DoSomething();
        }
    }

    public void DoSomething()
    {
        objectOnTrack.transform.position = ujung.position;
    }

    public void OnTriggerExit(Collider other)
    {
        OnLost();
        
    }

    public void Use(GameObject obj)
    {
        onTrack = true;
        objectOnTrack = obj;
    }

    public void OnLost()
    {
        onTrack = false;
        objectOnTrack = null;
    }
}
