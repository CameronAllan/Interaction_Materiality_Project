using UnityEngine;

public class Button_ColourChangeEffect : Effect
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Color _colour;

    public override void Play()
    {
        _renderer.color = _colour;
    }
}
