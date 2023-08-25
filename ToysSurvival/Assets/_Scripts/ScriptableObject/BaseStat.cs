using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BaseStat : ScriptableObject
{
    public int maxHP;
    public int currentHP;
    public int damage;

    public Sound[] sfxSounds;
}
