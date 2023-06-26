using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cars : Props
{
    [SerializeField] private bool isDriving = false;
    [SerializeField] private PrometeoCarController[] allController;

    [SerializeField] private float checkPlayerInDistanceRadius;
    [SerializeField] private LayerMask playerLayer;

    private void Start()
    {
        allController = GetComponentsInChildren<PrometeoCarController>();
        foreach (var item in allController)
        {
            item.enabled = isDriving;
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
}
