using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RagdollPanel : MonoBehaviour
{
    [SerializeField] private Button b_all;
    [SerializeField] private Button[] allRagdoll;

    [SerializeField] private ModelType currentProps = ModelType.Ragdoll;

    private void OnEnable()
    {
        b_all.Select();

        currentProps = ModelType.Ragdoll;

        HideAll();

        foreach (var item in allRagdoll)
        {
            item.gameObject.SetActive(true);
        }
    }

    private void HideAll()
    {
        foreach (var item in allRagdoll)
        {
            item.gameObject.SetActive(false);
        }

    }

    private void Start()
    {
        b_all.onClick.AddListener(() =>
        {
            HideAll();
            foreach (var item in allRagdoll)
            {
                item.gameObject.SetActive(true);
            }
            currentProps = ModelType.Ragdoll;
        });
    }

    public void PropsPotrait(int n)
    {
        GameSetting.Instance.CreateProp(currentProps, n);
    }
}
