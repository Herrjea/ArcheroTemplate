using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] protected float circleDuration = 0.05f;
    [SerializeField] protected int iterations = 2;

    protected GameObject whiteCircle;
    protected GameObject blackCircle;
    protected GameObject body;


    protected virtual void Awake()
    {
        whiteCircle = transform.Find("VFX").transform.Find("WhiteCircle").gameObject;
        blackCircle = transform.Find("VFX").transform.Find("BlackCircle").gameObject;

        whiteCircle.SetActive(false);
        blackCircle.SetActive(false);

        body = transform.Find("Body").gameObject;
    }


    public virtual void Play()
    {
        StartCoroutine(AnimationCoroutine());
    }

    protected IEnumerator AnimationCoroutine()
    {
        body.SetActive(false);

        for (int i = 0; i < iterations; i++)
        {
            whiteCircle.SetActive(true);
            yield return new WaitForSeconds(circleDuration);

            whiteCircle.SetActive(false);
            blackCircle.SetActive(true);
            yield return new WaitForSeconds(circleDuration);

            blackCircle.SetActive(false);
        }

        gameObject.SetActive(false);
    }
}
