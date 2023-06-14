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
        b_weld.onClick.AddListener(() => SetDetail(0));
        b_remove.onClick.AddListener(() => SetDetail(1));
        b_duplicate.onClick.AddListener(() => SetDetail(2));
        b_thruster.onClick.AddListener(() => SetDetail(3));
        b_hoverBall.onClick.AddListener(() => SetDetail(4));
        b_dinamyte.onClick.AddListener(() => SetDetail(5));
        
        b_weld.Select();
    }

    private void SetDetail(int n)
    {
        label_judul.text = details[n].judul;
        label_desc.text = details[n].deskripsi;
    }
}
