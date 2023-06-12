using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCanvasManager : CanvasManager
{
    [SerializeField] private Button b_main;
    [SerializeField] private Button b_level;
    [SerializeField] private Button b_load;
    [SerializeField] private Button b_help;

    private void OnEnable()
    {
        GameManager.Instance.OnStateChange += Instance_OnStateChange;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnStateChange -= Instance_OnStateChange;
    }

    private void Instance_OnStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Menu:
                SetPage(PageName.Menu);
                break;
            case GameState.Help:
                SetPage(PageName.Help);
                break;
            case GameState.Load:
                SetPage(PageName.Load);
                break;
            case GameState.Level:
                SetPage(PageName.Level);
                break;
        }
    }

    private void Start()
    {
        b_main.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Menu));
        b_level.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Level));
        b_load.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Load));
        b_help.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Help));

        GameManager.Instance.ChangeState(GameState.Menu);
        b_main.Select();
    }
}
