using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] float circleDuration = 0.05f;
    [SerializeField] int iterations = 2;

    GameObject whiteCircle;
    GameObject blackCircle;
    GameObject body;


    void Awake()
    {
        whiteCircle = transform.Find("VFX").transform.Find("WhiteCircle").gameObject;
        blackCircle = transform.Find("VFX").transform.Find("BlackCircle").gameObject;

        whiteCircle.SetActive(false);
        blackCircle.SetActive(false);

        body = transform.Find("Body").gameObject;
    }


    public void Play()
    {
        StartCoroutine(AnimationCoroutine());
    }

    IEnumerator AnimationCoroutine()
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
