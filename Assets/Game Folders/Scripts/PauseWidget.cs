using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseWidget : Widget
{
    [SerializeField] private Button b_resume;
    [SerializeField] private Button b_save;
    [SerializeField] private Button b_setting;
    [SerializeField] private Button b_exit;

    private void Start()
    {
        b_resume.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Game));
        b_save.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Save));
        b_setting.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Setting));
        b_exit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Main Menu");
        });
    }
}
