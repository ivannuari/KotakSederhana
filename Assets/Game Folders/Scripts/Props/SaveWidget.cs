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
            panel_info.SetActive(true);
            StartCoroutine(Loading());

            panel_info.SetActive(false);
            GameManager.Instance.ChangeState(GameState.Pause);
            
            GameManager.Instance.SaveData(input_save.text);
        });
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(1f);
        
    }
}
