using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuEditPage : Page
{
    [SerializeField] private Button b_close;

    [SerializeField] private Button b_props;
    [SerializeField] private Button b_tools;
    [SerializeField] private Button b_ragdoll;
    [SerializeField] private Button b_vehicle;
    [SerializeField] private Button b_option;

    [SerializeField] private GameObject[] panels;

    protected override void OnEnable()
    {
        base.OnEnable();
        b_props.Select();
        SetPanel(0);
    }

    private void Start()
    {
        b_close.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Game));

        b_props.onClick.AddListener(() => SetPanel(0));
        b_tools.onClick.AddListener(() => SetPanel(1));
        b_ragdoll.onClick.AddListener(() => SetPanel(2));
        b_vehicle.onClick.AddListener(() => SetPanel(3));
        b_option.onClick.AddListener(() => SetPanel(4));
    }

    private void SetPanel(int n)
    {
        foreach (var p in panels)
        {
            p.SetActive(false);
        }

        panels[n].SetActive(true);
    }
}
