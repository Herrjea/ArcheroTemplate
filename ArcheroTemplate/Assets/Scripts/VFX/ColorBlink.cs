using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBlink : MonoBehaviour
{
    [SerializeField] Material material = null;
    Material actualMaterial;

    [SerializeField] float blinkDuration = .05f;
    [SerializeField] int repetitions = 3;

    int blinkAmountId;
    Coroutine blinkCoroutine = null;


    protected virtual void Awake()
    {
        blinkAmountId = Shader.PropertyToID("_BlinkAmount");

        if (material == null)
            Debug.LogError("Material not set at ColorBlink::material on object " + gameObject.name);

        // Make a copy of the specified material,
        // so that changes to its properties
        // don't affect other objects
        actualMaterial = new Material(material);

        // Make all model parts use the new material
        foreach (Transform part in transform.Find("Model"))
            part.GetComponent<MeshRenderer>().material = actualMaterial;
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
            actualMaterial.SetFloat(blinkAmountId, 1);

            yield return new WaitForSeconds(duration);

            actualMaterial.SetFloat(blinkAmountId, 0);

            yield return new WaitForSeconds(duration);
        }
    }

    private void OnDestroy()
    {
        Destroy(actualMaterial);
    }
}
