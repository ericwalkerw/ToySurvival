using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class GameSaving : ScriptableObject
{
    public int TopScore = -1;
    public int Score = -1;
    public float time;

    private float startTime;

    public void StartGame()
    {
        startTime = Time.time;
    }

    public void UpdateTime()
    {
        time = Time.time - startTime;
    }

    public void isTopKill()
    {
        if (Score > TopScore)
        {
            TopScore = Score;
        }
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
