using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EffectTimelineUI : Singleton<EffectTimelineUI>
{
    public EffectEntryUI SelectedEntry;

    [Header("Display Vars")]
    [SerializeField] private UIEffect _timelineVisibilityEffect;
    [SerializeField] private UIEffect _libraryVisibilityEffect;

    [SerializeField] private List<TextMeshProUGUI> _titleTexts;

    [Header("Effect Tracks Vars")]
    [SerializeField] private Transform _effectTracksHolder;
    [SerializeField] private List<EffectTrackUI> _activeTrackUIs;


    [Header("Effect Library Vars")]
    [SerializeField] private Transform _effectsHolder;
    [SerializeField] private List<EffectSelectUI> _activeEffectUIs;


    [Header("Prefabs")]
    [SerializeField] private GameObject _effectTrackPrefab;
    [SerializeField] private GameObject _effectSlotPrefab;

    public void PopulateEffectLibrary(List<Effect> allEffects)
    {
        foreach(EffectSelectUI e in _activeEffectUIs)
        {
            e.gameObject.SetActive(false);
        }

        for(int x = 0; x < allEffects.Count; x++)
        {
            if(x < _activeEffectUIs.Count)
            {
                _activeEffectUIs[x].gameObject.SetActive(true);
                _activeEffectUIs[x].PopulateEffectSelect(allEffects[x], this);
            }
        }
    }

    public void DisplayInteractionTarget(InteractionTarget target)
    {
        //This is actually upside down, a little bit - I think I'm going to have to refactor the InteractionChains to maybe live on the target?
        //The "chains" are like columns in this graph when they should be rows, I'm over-complicating it
        SelectedEntry = null;

        foreach(TextMeshProUGUI text in _titleTexts)
        {
            text.text = "";
        }

        //List<InteractionChain> defaults = target.GetDefaultInteractions();
        int targetEffectSlots = target.GetInteractionSlotCount();
        List<string> slotName = target.GetSlotNames();

        for (int x = 0; x < targetEffectSlots; x++)
        {
            if(x < _titleTexts.Count)
            {
               
                _titleTexts[x].text = slotName[x];
            }
        }

        foreach(EffectTrackUI track in _activeTrackUIs)
        {
            track.gameObject.SetActive(false);
        }

        int slotsDepth = target.GetInteractionDepth();

        Debug.Log(slotsDepth + " = slotsDepth");

        for(int y =  0; y < slotsDepth; y++)
        {
            List<EffectSlot> slots = new List<EffectSlot>();
            for(int x = 0; x < targetEffectSlots; x++)
            {
                InteractionChain iChain = target.TryGetAddedEffectByIndex(x);
                if(iChain != null)
                {
                    EffectSlot eSlot = iChain.TryGetSlotAtIndex(y);
                    if(eSlot != null)
                        slots.Add(eSlot);
                }
            }

            if (y < _activeTrackUIs.Count)
            {
                _activeTrackUIs[y].gameObject.SetActive(true);
                _activeTrackUIs[y].PopulateTrackUI(slots, this);
            }
        }
    }

    public void AddEffectTrack(InteractionManager.InteractionTypes type)
    {

    }

    public void EntrySelected(EffectEntryUI entry)
    {
        SelectedEntry = entry;

        foreach(EffectTrackUI track in _activeTrackUIs)
        {
            track.ClearEntries(entry);
        }
    }

    public void DeselectEntry()
    {
        SelectedEntry.DeselectEntry();
        SelectedEntry = null;
    }

    public void EffectSelected(Effect effect)
    {
        if(SelectedEntry != null)
        {
            SelectedEntry.SetEffect(effect);
            SelectedEntry.DeselectEntry();
            SelectedEntry = null;
        }
    }

    public void ToggleVisible()
    {
        if (_timelineVisibilityEffect.isActive)
        {
            _timelineVisibilityEffect.isActive = false;
            _libraryVisibilityEffect.isActive = false;
        }
        else
        {
            _timelineVisibilityEffect.isActive = true;
            _libraryVisibilityEffect.isActive = true;
        }
    }
}
