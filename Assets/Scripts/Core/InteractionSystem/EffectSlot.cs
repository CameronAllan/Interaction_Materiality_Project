using UnityEngine;

public class EffectSlot : MonoBehaviour
{
    [SerializeField] private Effect _startingEffect;
    public Effect CurrentEffect { get; private set; }

    [SerializeField] private bool _specificDuration;
    [SerializeField] private float _duration;

    private void Awake()
    {
        //Kinda gross, but whatev
        if (_startingEffect != null)
            SetEffect(_startingEffect);
    }

    public void SetEffect(Effect effect)
    {
        CurrentEffect = effect;
    }

    public void ClearEffect()
    {
        CurrentEffect = null;
    }
}
