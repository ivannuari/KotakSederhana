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

    private void OnEnable()
    {
        b_furniture.Select();
    }

    private void Start()
    {
        b_furniture.Select();
    }
}
