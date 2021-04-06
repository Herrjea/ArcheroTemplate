using System.Collections;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    [SerializeField] protected float circleDuration = 0.05f;
    [SerializeField] protected int iterations = 2;

    protected GameObject whiteCircle;
    protected GameObject blackCircle;
    protected GameObject model;
    protected EnemyRotation[] rotations;


    protected virtual void Awake()
    {
        whiteCircle = transform.Find("VFX").transform.Find("WhiteCircle").gameObject;
        blackCircle = transform.Find("VFX").transform.Find("BlackCircle").gameObject;

        whiteCircle.SetActive(false);
        blackCircle.SetActive(false);

        model = transform.Find("Model").gameObject;
        rotations = GetComponents<EnemyRotation>();
    }


    public virtual void Play()
    {
        StartCoroutine(AnimationCoroutine());
    }

    protected IEnumerator AnimationCoroutine()
    {
        model.SetActive(false);
        foreach (EnemyRotation rotation in rotations)
            rotation.enabled = false;
        transform.rotation = Quaternion.identity;

        for (int i = 0; i < iterations; i++)
        {
            whiteCircle.SetActive(true);
            yield return new WaitForSeconds(circleDuration);

            whiteCircle.SetActive(false);
            blackCircle.SetActive(true);
            yield return new WaitForSeconds(circleDuration);

            blackCircle.SetActive(false);
        }

        Destroy(gameObject);
    }
}
