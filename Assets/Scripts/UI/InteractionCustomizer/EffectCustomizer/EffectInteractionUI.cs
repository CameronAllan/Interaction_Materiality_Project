using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class EffectInteractionUI : MonoBehaviour
{
    [SerializeField] private EffectTimelineUI _parent;
    [SerializeField] private InteractionChain _displayed;

    [SerializeField] private RectTransform _transform;
    [SerializeField] private List<EffectEntryUI> _activeSlots;
    [SerializeField] private float _slotHeight = 132f;
    [SerializeField] private RectTransform _slotHolder;
    [SerializeField] private Button _addSlotButton;

    public void PopulateInteractionUI(InteractionChain interactionChain, EffectTimelineUI parent)
    {
        _parent = parent;
        _displayed = interactionChain;

        foreach(EffectEntryUI entry in _activeSlots)
        {
            entry.DeselectEntry();
            entry.gameObject.SetActive(false);
        }

        switch (interactionChain)
        {
            default:
            case ICDiscrete:

                List<EffectSlot> slots = interactionChain.GetSlots();
                for(int x = 0; x < slots.Count; x++)
                {
                    if(x < _activeSlots.Count)
                    {
                        _activeSlots[x].gameObject.SetActive(true);
                        _activeSlots[x].SetEffectSlot(slots[x], this);
                    } else
                    {
                        AddEffectSlotUI(slots[x]);
                    }
                }
            break;
        }

        ResizeSlotHolder();
    }

    public void FilterDisplayedEffects(InteractionManager.InteractionTypes type)
    {

    }
    
    public void AddEffectSlotUI(EffectSlot slot = null)
    {
        if (_parent == null)
            return;

        EffectEntryUI entry = _parent.GetEffectSlotUIPrefab().GetComponent<EffectEntryUI>();
        if (entry != null)
        {
            EffectEntryUI newEntry = Instantiate(entry, _slotHolder).GetComponent<EffectEntryUI>();
            _activeSlots.Add(newEntry);

            if(slot != null)
                newEntry.SetEffectSlot(slot, this);

            ResizeSlotHolder();
        }
    }

    private void ResizeSlotHolder()
    {
        _transform.sizeDelta = new Vector2(_transform.sizeDelta.x, _activeSlots.Count * _slotHeight);
    }

    public void AddEffectSlotToInteractionChain()
    {
        if (_displayed != null)
        {

        }
    }

}
