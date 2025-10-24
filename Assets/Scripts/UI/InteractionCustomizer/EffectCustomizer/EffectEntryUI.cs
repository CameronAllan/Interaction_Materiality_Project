using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EffectEntryUI : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private EffectTrackUI _parent;
    [SerializeField] private EffectSlot _displayedSlot;

    [SerializeField] private GameObject _selectionMarker;
    [SerializeField] private Transform _effectDisplay;
    [SerializeField] private TextMeshProUGUI _effectName;

    public void SetEffectSlot(EffectSlot slot, EffectTrackUI parent)
    {
        _parent = parent;
        _displayedSlot = slot;

        if(_displayedSlot.CurrentEffect != null)
        {
            DisplayEffect(_displayedSlot.CurrentEffect);
        } else
        {
            ClearDisplayEffect();
        }
    }

    public void SetEffect(Effect effect)
    {
        if(_displayedSlot.CurrentEffect != null)
            _displayedSlot.ClearEffect();

        _displayedSlot.SetEffect(effect);

        DisplayEffect(_displayedSlot.CurrentEffect);

    }

    private void DisplayEffect(Effect effect)
    {
        _effectName.text = effect.name;
        _effectDisplay.gameObject.SetActive(true);
    }

    private void ClearDisplayEffect()
    {
        _effectDisplay.gameObject.SetActive(false);
    }

    public void ClearEffect()
    {
        _displayedSlot.ClearEffect();
        ClearDisplayEffect();
    }

    private void SelectEntry()
    {
        _parent.EntrySelected(this);
        _selectionMarker.SetActive(true);
    }

    public void DeselectEntry()
    {
        _selectionMarker.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectEntry();
    }
}
