using Ivannuari;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPage : Page
{
    [SerializeField] private SaveCard card;
    [SerializeField] private Transform content;

    [SerializeField] private Sprite[] gambars;

    protected override void OnEnable()
    {
        base.OnEnable();

        for (int i = 0; i < GameManager.Instance.GetSaveData().allSaveData.Count; i++)
        {
            SaveCard c = Instantiate(card, content);

            int n = GameManager.Instance.GetSaveData().allSaveData[i].nomorPlane;
            PlaneType tipe = PlaneType.Grass;
            if(n == 0)
            {
                tipe = PlaneType.Grass;
            }
            if(n == 1)
            {
                tipe = PlaneType.Sand;
            }
            if(n == 2)
            {
                tipe = PlaneType.Stone;
            }

            c.InitCard(gambars[GameManager.Instance.GetSaveData().allSaveData[i].nomorPlane] , GameManager.Instance.GetSaveData().allSaveData[i].nama , tipe);
        }
    }

    private void OnDisable()
    {
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }
    }
}
