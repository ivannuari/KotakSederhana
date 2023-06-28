using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveCard : MonoBehaviour
{
    private Button b_klik;
    private Image icon;

    private PlaneType tipe;

    [SerializeField] private TMP_Text label_saveName;

    private void OnEnable()
    {
        b_klik = GetComponent<Button>();
        icon = GetComponent<Image>();
    }

    public void InitCard(Sprite gambar ,string nama , PlaneType tipe)
    {
        if(gambar == null)
        {
            return;
        }
        icon.sprite = gambar;
        label_saveName.text = nama;
        this.tipe = tipe;

        b_klik.onClick.AddListener(() => LoadGame());
    }

    private void LoadGame()
    {
        GameManager.Instance.SetLevelPlane(tipe);
        GameManager.Instance.adsManager.RequestInterstitial();
        SceneManager.LoadScene("Gameplay");
    }
}
