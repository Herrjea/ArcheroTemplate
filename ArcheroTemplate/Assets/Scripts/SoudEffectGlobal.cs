using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoudEffectGlobal : MonoBehaviour
{
    [SerializeField] private SoundBank sfxBankReference;
    [SerializeField] private SoundBank musicBankReference;
    [SerializeField] private AudioSource sfxAudioEmitter;
    [SerializeField] private AudioSource musicAudioEmitter;

    private Dictionary<string, SoundBank.SoundDefinition> sfxSoundBank { get; set; }
    private Dictionary<string, SoundBank.SoundDefinition> musicSoundBank { get; set; }

    private void Awake()
    {
        sfxSoundBank = sfxBankReference.GetBankDictionary();
        musicSoundBank = musicBankReference.GetBankDictionary();
    }

    private void OnEnable()
    {
        GameEvents.EnemyDied.AddListener(EnemyDeathEvent);
        GameEvents.PlayerShot.AddListener(PlayerShotEvent);
        GameEvents.AddSoftCoins.AddListener(SoftCoinPickUpEvent);
        GameEvents.PlayerGotHealed.AddListener(PlayerGotHealedEvent);
        GameEvents.PlayerGotHit.AddListener(PlayerGotHitEvent);
        GameEvents.EnemyShot.AddListener(EnemyShotEvent);

        GameEvents.EnterMenu.AddListener(EnterMenu);
        GameEvents.EnterGame.AddListener(EnterGame);

        //EnterMenu();
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


    private void EnterMenu() => ChangeMusic("MenuTheme");

    private void EnterGame() => ChangeMusic("GameTheme");


    private void FireEvent(string key)
    {
        if (sfxSoundBank.TryGetValue(key, out var sound))
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
        sfxAudioEmitter.PlayOneShot(clip, volume);
    }

    private void ChangeMusic(string key)
    {
        if (musicSoundBank.TryGetValue(key, out var sound))
        {
            PlayMusic(sound.Clip, sound.Volume);
        }
        else
        {
            Debug.LogError("Sound Event " + key + " not found.");
        }
    }

    private void PlayMusic(AudioClip clip, float volume)
    {
        musicAudioEmitter.PlayOneShot(clip, volume);
    }
}