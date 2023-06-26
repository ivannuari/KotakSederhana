using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VehiclePanel : MonoBehaviour
{
    [SerializeField] private Button b_car;
    [SerializeField] private Button b_other;

    [SerializeField] private Button[] allCars;
    [SerializeField] private Button[] allOthers;

    [SerializeField] private ModelType currentProps = ModelType.Furniture;

    private void OnEnable()
    {
        b_car.Select();

        currentProps = ModelType.Cars;

        HideAll();

        foreach (var item in allCars)
        {
            item.gameObject.SetActive(true);
        }
    }

    private void HideAll()
    {
        foreach (var item in allCars)
        {
            item.gameObject.SetActive(false);
        }

        foreach (var item in allOthers)
        {
            item.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        b_car.onClick.AddListener(() =>
        {
            HideAll();
            foreach (var item in allCars)
            {
                item.gameObject.SetActive(true);
            }
            currentProps = ModelType.Cars;
        });

        b_other.onClick.AddListener(() =>
        {
            HideAll();
            foreach (var item in allOthers)
            {
                item.gameObject.SetActive(true);
            }
            currentProps = ModelType.Others;
        });
    }

    public void PropsPotrait(int n)
    {
        GameSetting.Instance.CreateProp(currentProps, n);
    }
}
