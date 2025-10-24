using UnityEngine;

public class SoundEffect : Effect
{
    [SerializeField] private AudioSource source;


    public override void Play()
    {
        source.Play();
    }
}
