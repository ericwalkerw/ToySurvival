using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManeger : MonoBehaviour
{
    #region SingleTon
    public static UIManeger Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public BaseStat stat;
    public PlayerSetting setting;
    public GameSaving save;
    [Header("HP")]
    public Image HP;
    [Header("Volume")]
    public Slider musicVolume, sfxVolume;
    [Header("Saving")]
    public TMP_Text topKill;
    public TMP_Text currentKill;
    public TMP_Text time;
    private void Start()
    {
        topKill.text = save.TopScore.ToString();
        currentKill.text = save.Score.ToString();
        time.text = save.time.ToString();

        musicVolume.value = setting.musicValue;
        sfxVolume.value = setting.sfxValue;

        if (!GameManeger.Instance.isStart) return;
        save.StartGame();
    }
    private void Update()
    {
        UpdateHP();
        UpdateVolume();
        UpdateScore();
    }

    public void UpdateHP()
    {
        HP.fillAmount = (stat.currentHP / (float)stat.maxHP);
    }

    public void UpdateVolume()
    {
        setting.musicValue = musicVolume.value;
        setting.sfxValue = sfxVolume.value;
        GameAudio.instance.musicSource.volume = setting.musicValue;
        GameAudio.instance.playerSource.volume = setting.sfxValue;
    }

    public void UpdateScore()
    {
        topKill.text = (save.TopScore).ToString();
        currentKill.text = (save.Score).ToString();
        time.text = save.GetFormattedTime();
    }

    private void OnApplicationQuit()
    {
        setting.musicValue = musicVolume.value;
        setting.sfxValue = sfxVolume.value;

        save.TopScore = int.Parse(topKill.text);
    }
}
