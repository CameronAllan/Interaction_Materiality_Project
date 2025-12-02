
using UnityEngine;

public class BumpZoomEffect : Effect
{
    [SerializeField] private float _zoomMagnitude;
    public override void Play()
    {
        CameraShake.Instance.BumpZoom(_zoomMagnitude);
    }
}
