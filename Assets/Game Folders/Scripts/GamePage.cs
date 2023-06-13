using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePage : Page
{
    [SerializeField] private Button b_pause;
    [SerializeField] private Button b_switch;
    [SerializeField] private Button b_menu;
    [SerializeField] private Button b_build;
    [SerializeField] private Button b_delete;

    private void Start()
    {
        b_pause.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Pause));

    }
}
