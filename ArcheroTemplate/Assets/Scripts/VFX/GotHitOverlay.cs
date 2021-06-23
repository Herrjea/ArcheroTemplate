using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHitOverlay : MonoBehaviour
{
    [SerializeField] float duration = 1;
    float remaining;

    Material material;

    int strengthId;
    Coroutine coroutine = null;


    private void Awake()
    {
        material = GetComponent<MeshRenderer>().material;

        strengthId = Shader.PropertyToID("_Strength");

        GameEvents.PlayerGotHit.AddListener(OnPlayerGotHit);
    }


    void OnPlayerGotHit(float amount)
    {
        if (coroutine == null)
            coroutine = StartCoroutine(GotHitCoroutine());
        else
            remaining = duration;
    }

    IEnumerator GotHitCoroutine()
    {
        remaining = duration;

        while (remaining > 0)
        {
            material.SetFloat(strengthId, remaining / duration);

            remaining -= Time.deltaTime;

            yield return null;
        }

        coroutine = null;
    }
}
