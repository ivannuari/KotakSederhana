using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSatu : Gun
{
    [SerializeField] private Transform ujung;
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
            objTemp.GetComponent<Rigidbody>().isKinematic = true;
            objTemp.transform.position = ujung.position;
        }
        else
        {
            if(objTemp!=null)
            {
                objTemp.GetComponent<Rigidbody>().isKinematic = false;
                objTemp = null;
            }
        }
    }

    private void OnDisable()
    {
        objTemp = null;
    }
}
