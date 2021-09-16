using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "SoundBank", fileName = "NewSoundBank")]
public class SoundBank : ScriptableObject
{
    [SerializeField] private List<SoundDefinition> bank;

    public Dictionary<string, SoundDefinition> GetBankDictionary() => bank.ToDictionary(sound => sound.EventKey);

    [Serializable]
    public class SoundDefinition
    {
        public AudioClip Clip;
        public string EventKey ="NOKEY";
        public float Volume = 1f;
    }
}