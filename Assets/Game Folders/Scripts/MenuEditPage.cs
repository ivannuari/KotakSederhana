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

    [SerializeField] private Button b_furniture;
    [SerializeField] private Button b_street;
    [SerializeField] private Button b_cartoon;
    [SerializeField] private Button b_buildings;
    [SerializeField] private Button b_people;
    [SerializeField] private Button b_primitive;
    [SerializeField] private Button b_roads;

    private void Start()
    {
        b_close.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Game));

        
    }
}
