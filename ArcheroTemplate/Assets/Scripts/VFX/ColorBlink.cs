using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlink : MonoBehaviour
{
    [SerializeField] Material material = null;

    [SerializeField] float blinkDuration = .05f;
    [SerializeField] int repetitions = 3;

    int blinkAmountId;
    Coroutine blinkCoroutine = null;


    protected virtual void Awake()
    {
        blinkAmountId = Shader.PropertyToID("_BlinkAmount");

        if (material == null)
            Debug.LogError("Material not set at ColorBlink::material on object " + gameObject.name);

        material.SetFloat(blinkAmountId, 0);
    }


    public virtual void OnGotHit(float damage)
    {
        Blink();
    }

    public void Blink()
    {
        if (blinkCoroutine != null)
            StopCoroutine(blinkCoroutine);
        blinkCoroutine = StartCoroutine(BlinkCoroutine(blinkDuration));
    }

    protected IEnumerator BlinkCoroutine(float duration)
    {
        for (int i = 0; i < repetitions; i++)
        {
            material.SetFloat(blinkAmountId, 1);

            yield return new WaitForSeconds(duration);

            material.SetFloat(blinkAmountId, 0);

            yield return new WaitForSeconds(duration);
        }
    }
}
