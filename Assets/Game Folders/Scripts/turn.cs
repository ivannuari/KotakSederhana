using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    [SerializeField, Range(50f, 150f)] private float turnSpeed = 100f;

    private void Update()
    {
        transform.Rotate(turnSpeed * Time.deltaTime, 0f, 0f);
    }
}
