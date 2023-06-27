using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : Props
{
    [SerializeField] private bool isDriving = false;
    [SerializeField] private PrometeoCarController[] allController;

    [SerializeField] private float checkPlayerInDistanceRadius;
    [SerializeField] private float camSpeed = 2f;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private GameObject[] allCams;

    private void Start()
    {
        allController = GetComponentsInChildren<PrometeoCarController>();
        foreach (var item in allController)
        {
            item.enabled = isDriving;
        }
    }

    private void OnEnable()
    {
        GameManager.Instance.OnStateChange += Instance_OnStateChange;
    }

    private void OnDisable()
    {
        GameManager.Instance.OnStateChange -= Instance_OnStateChange;
    }

    private void Instance_OnStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Vehicle:
                GameSetting.Instance.EnterCar(this, true);
                break;
            case GameState.Game:
                DeactivateCar();
                break;
        }
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        bool checkRange = Physics.CheckSphere(transform.GetChild(indexSelected).position, checkPlayerInDistanceRadius, playerLayer);
        GameSetting.Instance.SetRangeOfCar(checkRange);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.GetChild(indexSelected).position, checkPlayerInDistanceRadius);
    }

    public void ActivateCar()
    {
        allController[indexSelected].enabled = true;
        allCams[indexSelected].SetActive(true);
    }
    
    public void DeactivateCar()
    {
        allController[indexSelected].enabled = false;
        allCams[indexSelected].SetActive(false);
    }

    public PrometeoCarController GetCar()
    {
        return allController[indexSelected];
    }
}
