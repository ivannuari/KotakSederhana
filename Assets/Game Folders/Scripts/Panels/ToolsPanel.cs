using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ToolsPanel : MonoBehaviour
{

    [System.Serializable]
    public class ToolsDetail
    {
        public string judul;
        public string deskripsi;
        public GameObject panel;
    }

    [SerializeField] private ToolsDetail[] details;

    [SerializeField] private Button b_weld;
    [SerializeField] private Button b_remove;
    [SerializeField] private Button b_duplicate;
    [SerializeField] private Button b_thruster;
    [SerializeField] private Button b_hoverBall;
    [SerializeField] private Button b_dinamyte;

    [SerializeField] private TMP_Text label_judul;
    [SerializeField] private TMP_Text label_desc;

    private void OnEnable()
    {
        b_weld.Select();
        SetDetail(0);
    }

    private void Start()
    {
        b_weld.onClick.AddListener(() =>
        {
            WeaponManager.Instance.SetWeapon(WeaponType.Weld);
            SetDetail(0);
        });

        b_remove.onClick.AddListener(() =>
        {
            WeaponManager.Instance.SetWeapon(WeaponType.Remove);
            SetDetail(1); 
        });

        b_duplicate.onClick.AddListener(() =>
        {
            WeaponManager.Instance.SetWeapon(WeaponType.Duplicate);
            SetDetail(2);
        });

        b_thruster.onClick.AddListener(() =>
        {
            WeaponManager.Instance.SetWeapon(WeaponType.Thruster);
            SetDetail(3);
        });

        b_hoverBall.onClick.AddListener(() =>
        {
            WeaponManager.Instance.SetWeapon(WeaponType.Hoverball);
            SetDetail(4);
        });
        b_dinamyte.onClick.AddListener(() =>
        {
            WeaponManager.Instance.SetWeapon(WeaponType.Dynamite);
            SetDetail(5);
        });
        
        b_weld.Select();
    }

    private void SetDetail(int n)
    {
        label_judul.text = details[n].judul;
        label_desc.text = details[n].deskripsi;

        foreach (ToolsDetail item in details)
        {
            if(item.panel != null)
            {
                item.panel.SetActive(false);
            }
        }

        if(details[n].panel != null)
        {
            details[n].panel.SetActive(true);
        }
    }
}
