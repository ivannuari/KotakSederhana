using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelPage : Page
{
    [SerializeField] private Button b_levelA;
    [SerializeField] private Button b_levelB;
    [SerializeField] private Button b_levelC;

    private void Start()
    {
        b_levelA.onClick.AddListener(() => ChangeScene("Gameplay"));
    }
}
