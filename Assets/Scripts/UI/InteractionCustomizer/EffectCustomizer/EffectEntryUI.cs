using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EffectEntryUI : MonoBehaviour //IPointerClickHandler
{
    [SerializeField] private EffectInteractionUI _parent;
    [SerializeField] private EffectSlot _displayedSlot;

    [SerializeField] private GameObject _selectionMarker;
    [SerializeField] private Transform _effectDisplay;
    [SerializeField] private TextMeshProUGUI _effectName;
    [SerializeField] private Image _outlineBkg;
    [SerializeField] private Image _effectIcon;

    [SerializeField] private UIDropZone _dropZone;

    public void SetEffectSlot(EffectSlot slot, EffectInteractionUI parent)
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
        _effectName.text = effect.EffectName;
        _outlineBkg.color = effect.EffectColor;
        _effectIcon.sprite = effect.EffectIcon;

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

    public void SelectEntry()
    {
        //_parent.EntrySelected(this);
        _selectionMarker.SetActive(true);
    }

    public void DeselectEntry()
    {
        _selectionMarker.SetActive(false);
    }
    /*
    public void OnPointerClick(PointerEventData eventData)
    {
        SelectEntry();
    }
    */

    #region Listeners

    public void OnDropZoneSelectionChanged(object sender, EventArgs e)
    {

        HandleDropZoneChange();
    }

    private void HandleDropZoneChange()
    {
        EffectSelectUI selectUI = _dropZone.currentDraggable.GetParent().GetComponent<EffectSelectUI>();
        if(selectUI != null)
        {
            SetEffect(selectUI.GetEffect());
        } else
        {
            ClearEffect();
        }

        DeselectEntry();
    }

    private void OnEnable()
    {
        if (_dropZone != null)
            _dropZone.SelectionChanged += OnDropZoneSelectionChanged;
    }

    private void OnDisable()
    {
        if (_dropZone != null)
            _dropZone.SelectionChanged -= OnDropZoneSelectionChanged;
    }

    #endregion
}
