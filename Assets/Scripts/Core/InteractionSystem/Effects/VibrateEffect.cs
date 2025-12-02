using UnityEngine;

public class VibrateEffect : Effect
{
    public override void Play()
    {
        Handheld.Vibrate();
    }
}
