using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameAudio : MonoBehaviour
{
    #region SingleTon
    public static GameAudio instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    public Sound[] musicSounds;
    public AudioSource musicSource, playerSource, enemySource;

    private void Start()
    {
        PlayMusic("BackGround");
    }
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.soundName == name);
        if (s != null)
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySfxPlayer(BaseStat character, string name)
    {
        Sound s = Array.Find(character.sfxSounds, x => x.soundName == name);
        if (s != null)
        {
            playerSource.clip = s.clip;
            playerSource.Play();
        }
    }

    public void PlaySfx(BaseStat character, string name)
    {
        Sound s = Array.Find(character.sfxSounds, x => x.soundName == name);
        if (s != null)
        {
            enemySource.clip = s.clip;
            enemySource.Play();
        }
    }
}
