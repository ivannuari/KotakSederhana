using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuPage : Page
{
    [SerializeField] private TMP_Text label_versi;

    private void Start()
    {
        label_versi.text = $"version {Application.version}";
    }
}
