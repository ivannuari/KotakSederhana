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
        b_levelA.onClick.AddListener(() =>
        {
            GameManager.Instance.adsManager.RequestInterstitial();
            GameManager.Instance.SetLevelPlane(PlaneType.Grass);
            ChangeScene("Gameplay");
        });

        b_levelB.onClick.AddListener(() =>
        {
            GameManager.Instance.adsManager.RequestInterstitial();
            GameManager.Instance.SetLevelPlane(PlaneType.Sand);
            ChangeScene("Gameplay");
        });

        b_levelC.onClick.AddListener(() =>
        {
            GameManager.Instance.adsManager.RequestInterstitial();
            GameManager.Instance.SetLevelPlane(PlaneType.Stone);
            ChangeScene("Gameplay");
        });
    }
}
