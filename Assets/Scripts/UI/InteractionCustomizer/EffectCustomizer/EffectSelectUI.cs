using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectSelectUI : MonoBehaviour
{
    [SerializeField] private EffectTimelineUI _parentUI;
    [SerializeField] private Effect _effect;

    [Header("Display Vars")]
    [SerializeField] private TextMeshProUGUI _effectText;

    public void PopulateEffectSelect(Effect effect, EffectTimelineUI parent)
    {
        _parentUI = parent;
        _effect = effect;

        _effectText.text = effect.name;
    }

    public void SelectEffect()
    {
        _parentUI.EffectSelected(_effect);
    }
}
