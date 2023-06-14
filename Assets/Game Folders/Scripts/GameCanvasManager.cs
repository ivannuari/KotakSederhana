using Ivannuari;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCanvasManager : CanvasManager
{
    [SerializeField] private Widget[] allWidgets;

    private void Start()
    {
        GameManager.Instance.OnStateChange += Instance_OnStateChange;
        GameManager.Instance.ChangeState(GameState.Game);
    }

    private void OnDisable()
    {
        GameManager.Instance.OnStateChange -= Instance_OnStateChange;
    }

    private void Instance_OnStateChange(GameState newState)
    {
        switch (newState)
        {
            case GameState.Game:
                Time.timeScale = 1f;
                SetPage(PageName.Game);
                break;
            case GameState.Pause:
                SetPage(PageName.Pause);
                SetWidget(WidgetName.Pause);
                Time.timeScale = 0f;
                break;
            case GameState.Setting:
                SetWidget(WidgetName.Setting);
                break;
            case GameState.Save:
                SetWidget(WidgetName.Save);
                break;
            case GameState.EditMode:
                SetPage(PageName.EditMode);
                break;
        }
    }

    public void SetWidget(WidgetName findWidget)
    {
        foreach (var widget in allWidgets)
        {
            widget.gameObject.SetActive(false);
        }

        int temp = Array.FindIndex(allWidgets, w => w.nama == findWidget);
        allWidgets[temp].gameObject.SetActive(true);
    }
}
