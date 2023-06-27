using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSatu : Gun
{
    [SerializeField] private Transform ujung;
    [SerializeField] private Transform ujungJauh;
    private GameObject objTemp;

    public override void OnShootObject(GameObject obj)
    {
        if (gameObject.activeInHierarchy)
        {
            obj.transform.position = ujung.position;
            objTemp = obj;
        }
    }

    private void Update()
    {
        if(isOnShoot && gameObject.activeInHierarchy)
        {
            if (objTemp != null)
            {
                objTemp.GetComponent<Rigidbody>().isKinematic = true;
                if (objTemp.CompareTag("Besar"))
                {
                    objTemp.transform.position = ujungJauh.position;
                }
                else
                {
                    objTemp.transform.position = ujung.position;
                }
            }
        }
        else
        {
            if(objTemp != null)
            {
                objTemp.GetComponent<Rigidbody>().isKinematic = false;
                objTemp = null;
            }
        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        objTemp = null;
    }
}
