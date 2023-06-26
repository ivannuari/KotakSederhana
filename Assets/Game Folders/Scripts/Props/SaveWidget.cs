using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SaveWidget : Widget
{
    [SerializeField] private TMP_InputField input_save;
    [SerializeField] private Button b_save;
    [SerializeField] private Button b_cancel;
    [SerializeField] private GameObject panel_info;

    private void Start()
    {
        b_cancel.onClick.AddListener(() => GameManager.Instance.ChangeState(GameState.Pause));

        b_save.onClick.AddListener(() =>
        {
            if(string.IsNullOrEmpty(input_save.text))
            {
                return;
            }

            //save Data
            GameManager.Instance.SaveData(input_save.text);
            panel_info.SetActive(true);
            StartCoroutine(HidePanel());
        });
    }

    private void OnEnable()
    {
        panel_info.SetActive(false);
    }

    IEnumerator HidePanel()
    {
        yield return new WaitForSeconds(2f);
        panel_info.SetActive(false);
    }
}
