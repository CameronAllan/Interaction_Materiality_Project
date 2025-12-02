using UnityEngine;

public class ScreenShakeEffect : Effect
{
    [SerializeField] private float _shakeMagnitude;

    public override void Play()
    {
        CameraShake.Instance.ScreenShake(_shakeMagnitude);
    }
}
