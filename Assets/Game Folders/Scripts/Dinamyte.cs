using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dinamyte : MonoBehaviour
{
    public int firesNumber = 0;
    public float sliderMod = 0f;

    [SerializeField, Range(5f, 25f)] private float bombRadius;
    [SerializeField] private GameObject fx;
    [SerializeField] private GameObject mesh;

    private void OnEnable()
    {
        GameSetting.Instance.OnFiresNumber += Instance_OnFiresNumber;
    }

    private void OnDisable()
    {
        GameSetting.Instance.OnFiresNumber -= Instance_OnFiresNumber;
    }

    private void Instance_OnFiresNumber(int n)
    {
        if(firesNumber == n)
        {
            StartCoroutine(Detonade());
        }
    }

    IEnumerator Detonade()
    {
        yield return new WaitForSeconds(sliderMod);

        fx.SetActive(true);
        mesh.SetActive(false);

        Collider[] allColliders = Physics.OverlapSphere(transform.position, bombRadius);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, bombRadius);
    }
}
