using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectSelectUI : MonoBehaviour
{
    [SerializeField] private EffectTimelineUI _parentUI;
    [SerializeField] private Effect _effect;

    [Header("Display Vars")]
    [SerializeField] private TextMeshProUGUI _effectText;
    [SerializeField] private Image _effectBkg;
    [SerializeField] private Image _effectIcon;

    public void PopulateEffectSelect(Effect effect, EffectTimelineUI parent)
    {
        _parentUI = parent;
        _effect = effect;

        _effectText.text = effect.EffectName;
        _effectBkg.color = effect.EffectColor;
        _effectIcon.sprite = effect.EffectIcon;

    }

    public void SelectEffect()
    {
        _parentUI.EffectSelected(_effect);
    }

    public Effect GetEffect()
    {
        return _effect;
    }
}
