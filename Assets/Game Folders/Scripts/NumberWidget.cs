using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWidget : Widget
{
    [SerializeField] private Button[] b_fires;

    private void Start()
    {
        b_fires[0].onClick.AddListener(() => GameSetting.Instance.FiresButton(0));
        b_fires[1].onClick.AddListener(() => GameSetting.Instance.FiresButton(1));
        b_fires[2].onClick.AddListener(() => GameSetting.Instance.FiresButton(2));
        b_fires[3].onClick.AddListener(() => GameSetting.Instance.FiresButton(3));
        b_fires[4].onClick.AddListener(() => GameSetting.Instance.FiresButton(4));
        b_fires[5].onClick.AddListener(() => GameSetting.Instance.FiresButton(5));
        b_fires[6].onClick.AddListener(() => GameSetting.Instance.FiresButton(6));
        b_fires[7].onClick.AddListener(() => GameSetting.Instance.FiresButton(7));
        b_fires[8].onClick.AddListener(() => GameSetting.Instance.FiresButton(8));
    }
}
