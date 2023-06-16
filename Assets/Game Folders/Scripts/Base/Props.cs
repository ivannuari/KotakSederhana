using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Props : MonoBehaviour
{
    protected bool isGrounded;

    [SerializeField] protected int indexSelected = 0;
    [SerializeField] protected GameObject[] models;

    public void SetIndex(int n)
    {
        indexSelected = n;
        foreach (var item in models)
        {
            item.SetActive(false);
        }
        models[n].SetActive(true);
    }

    protected virtual void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.25f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.25f);
    }
}
