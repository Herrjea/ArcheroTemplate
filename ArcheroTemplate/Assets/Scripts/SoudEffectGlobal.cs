using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudEffectGlobal : MonoBehaviour
{
    [SerializeField] private SoundBank bankReference;
    [SerializeField] private AudioSource audioEmitter;

    private Dictionary<string, SoundBank.SoundDefinition> SoundBank { get; set; }

    private void Awake()
    {
        SoundBank = bankReference.GetBankDictionary();
    }

    private void OnEnable()
    {
        GameEvents.EnemyDied.AddListener(EnemyDeathEvent);
        GameEvents.PlayerShot.AddListener(PlayerShotEvent);
        GameEvents.AddSoftCoins.AddListener(SoftCoinPickUpEvent);
        GameEvents.PlayerGotHealed.AddListener(PlayerGotHealedEvent);
        GameEvents.PlayerGotHit.AddListener(PlayerGotHitEvent);
        GameEvents.EnemyShot.AddListener(EnemyShotEvent);
    }
    
    private void OnDisable()
    {
        GameEvents.EnemyDied.RemoveListener(EnemyDeathEvent);
        GameEvents.PlayerShot.RemoveListener(PlayerShotEvent);
        GameEvents.AddSoftCoins.RemoveListener(SoftCoinPickUpEvent);
        GameEvents.PlayerGotHealed.RemoveListener(PlayerGotHealedEvent);
        GameEvents.PlayerGotHit.RemoveListener(PlayerGotHitEvent);
    }

    private void EnemyShotEvent(float arg0) => FireEvent("EnemyShot");

    private void PlayerGotHitEvent(float arg0) => FireEvent("PlayerGotHit");

    private void PlayerGotHealedEvent(float arg0) => FireEvent("PlayerHealed");

    private void SoftCoinPickUpEvent(int arg0) => FireEvent("MoneyPicked");
    
    private void PlayerShotEvent(ObjectPool arg0, Vector3 arg1, Transform arg2, bool arg3) =>
        FireEvent("PlayerShot");
    
    private void EnemyDeathEvent(Vector3 arg0) => FireEvent("EnemyDeath");

    private void FireEvent(string key)
    {
        if (SoundBank.TryGetValue(key, out var sound))
        {
            PlaySound(sound.Clip, sound.Volume);
        }
        else
        {
            Debug.LogError("Sound Event " + key + " not found." );
        }
    }
    
    private void PlaySound(AudioClip clip, float volume)
    {
        audioEmitter.PlayOneShot(clip, volume);
    }
}