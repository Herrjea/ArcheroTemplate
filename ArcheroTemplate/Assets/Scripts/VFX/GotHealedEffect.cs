using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotHealedEffect : MonoBehaviour
{
    ParticleSystem particles;


    private void Awake()
    {
        particles = GetComponent<ParticleSystem>();

        GameEvents.PlayerGotHealed.AddListener(OnGotHealed);
    }


    void OnGotHealed(float amount)
    {
        particles.Play();
    }
}
