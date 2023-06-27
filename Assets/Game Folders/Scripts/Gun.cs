using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField , Range(50f , 100f)] protected float gunRange = 100f;
    [SerializeField] protected LayerMask propLayer;

    protected bool isOnShoot = false;
    protected Transform cam;

    protected virtual void Start()
    {
        cam = GetComponentInParent<Camera>().transform;
        
    }

    protected virtual void OnEnable()
    {
        GameSetting.Instance.OnShootAction += Shoot;
    }

    protected virtual void OnDisable()
    {
        GameSetting.Instance.OnShootAction -= Shoot;
    }

    public virtual void Shoot(bool isShoot)
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
    }

    public virtual void OnShootObject(GameObject obj)
    {
        
    }
}
