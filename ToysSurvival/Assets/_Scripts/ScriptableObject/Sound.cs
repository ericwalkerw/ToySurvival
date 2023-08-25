using UnityEngine;

[CreateAssetMenu()]
public class Sound : ScriptableObject 
{
    public string soundName;
    public AudioClip clip;

    private void OnValidate()
    {
        soundName = this.name;
    }
}
