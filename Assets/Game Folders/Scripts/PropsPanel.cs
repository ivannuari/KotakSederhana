using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PropsPanel : MonoBehaviour
{
    [SerializeField] private Button b_furniture;
    [SerializeField] private Button b_street;
    [SerializeField] private Button b_cartoon;
    [SerializeField] private Button b_buildings;
    [SerializeField] private Button b_people;
    [SerializeField] private Button b_primitive;
    [SerializeField] private Button b_roads;

    [SerializeField] private Button[] allFurnitures;
    [SerializeField] private Button[] allBuildings;
    [SerializeField] private Button[] allPeoples;

    [SerializeField] private ModelType currentProps = ModelType.Furniture;

    private void OnEnable()
    {
        b_furniture.Select();
        currentProps = ModelType.Furniture;
        HideAll();
        foreach (var item in allFurnitures)
        {
            item.gameObject.SetActive(true);
        }
    }

    private void HideAll()
    {
        foreach (var item in allFurnitures)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in allBuildings)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in allPeoples)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        HideAll();

        b_furniture.onClick.AddListener(() =>
        {
            HideAll();
            foreach (var item in allFurnitures)
            {
                item.gameObject.SetActive(true);
            }
            currentProps = ModelType.Furniture;
        });

        b_buildings.onClick.AddListener(() =>
        {
            HideAll();
            foreach (var item in allBuildings)
            {
                item.gameObject.SetActive(true);
            }
            currentProps = ModelType.Building;
        });

        b_people.onClick.AddListener(() =>
        {
            HideAll();
            foreach (var item in allPeoples)
            {
                item.gameObject.SetActive(true);
            }
            currentProps = ModelType.People;
        });
    }

    public void PropsPotrait(int n)
    {
        GameSetting.Instance.CreateProp(currentProps, n);
    }
}
