using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] float duration = .5f;

    Material material = null;
    int dissolveAmountId;


    void Awake()
    {
        dissolveAmountId = Shader.PropertyToID("_DissolveAmount");
    }


    public void StartDissolve()
    {
        StartCoroutine(DissolveCoroutine());
    }


    IEnumerator DissolveCoroutine()
    {
        print("aaaa " + gameObject.name);

        float remaining = 2;

        material = GetComponentInChildren<MeshRenderer>().material;

        while (remaining > 0)
        {
            material.SetFloat(dissolveAmountId, remaining);

            remaining -= Time.deltaTime;

            yield return null;
        }
    }
}
