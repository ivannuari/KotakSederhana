using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagdollPanel : MonoBehaviour
{
    [SerializeField] private Button b_all;

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        b_all.Select();
    }
}
