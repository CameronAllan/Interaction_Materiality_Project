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
    [SerializeField] private GameObject _scrollTargetButtons;
    [SerializeField] private UIEffect _tabHolderEffect;
    [SerializeField] private List<UIEffect> _tabEffects;


    [Header("Effect Interactions Vars")]
    [SerializeField] private List<EffectInteractionUI> _activeInteractionUIs;
    [SerializeField] private InteractionManager.InteractionTypes _displayedInteraction;
    [SerializeField] private InteractionManager.InteractionTypes _defaultInteractionType;


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

    public void DisplayInteractionTarget(InteractionTarget target, InteractionManager.InteractionTypes type = InteractionManager.InteractionTypes.Default)
    {
        SelectedEntry = null;
        int targetEffectSlots = target.GetInteractionSlotCount();

        if (type == InteractionManager.InteractionTypes.Default)
            type = _defaultInteractionType;

        for(int x = 0; x < targetEffectSlots; x++)
        {
            InteractionChain chain = target.TryGetAddedEffectByIndex(x);
            if(x < _activeInteractionUIs.Count && chain != null)
            {
                _activeInteractionUIs[x].PopulateInteractionUI(chain, this);
            }
        }

        DisplayEffectCategory(type);
    }

    public void AddEffectTrack(InteractionManager.InteractionTypes type)
    {

    }

    public void EntrySelected(EffectEntryUI entry)
    {
        /*
        SelectedEntry = entry;

        foreach(EffectTrackUI track in _activeTrackUIs)
        {
            track.ClearEntries(entry);
        }
        */
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
            _scrollTargetButtons.SetActive(false);
            _tabHolderEffect.isActive = false;
            StageAssetManager.Instance.CenterElementInView();
        }
        else
        {
            _timelineVisibilityEffect.isActive = true;
            _libraryVisibilityEffect.isActive = true;
            _tabHolderEffect.isActive = true;
            _scrollTargetButtons.SetActive(true);
            StageAssetManager.Instance.MoveElementToEditPosition();
        }
    }

    public GameObject GetEffectSlotUIPrefab()
    {
        return _effectSlotPrefab;
    }

    #region Effect Category Sorting

    public void DisplaySoundEffects()
    {
        DisplayEffectCategory(InteractionManager.InteractionTypes.Sound);
    }

    public void DisplayAnimationEffects()
    {
        DisplayEffectCategory(InteractionManager.InteractionTypes.Animation);
    }

    public void DisplayParticleEffects()
    {
        DisplayEffectCategory(InteractionManager.InteractionTypes.Particle);
    }

    public void DisplayFeedbackEffects()
    {
        DisplayEffectCategory(InteractionManager.InteractionTypes.Feedback);
    }

    public void DisplayEffectCategory(InteractionManager.InteractionTypes type)
    {
        DisplayTargetEffectsOfType(type);
        DisplayLibraryEffectsOfType(type);

        SelectInteractionTypeTab(type);
    }

    private void DisplayTargetEffectsOfType(InteractionManager.InteractionTypes type)
    {
        InteractionTarget target = InteractionManager.Instance.GetInteractionTarget();
        int targetEffectSlots = target.GetInteractionSlotCount();

        for (int x = 0; x < targetEffectSlots; x++)
        {
            InteractionChain chain = target.TryGetAddedEffectByIndex(x);
            if (x < _activeInteractionUIs.Count && chain != null)
            {
                _activeInteractionUIs[x].FilterDisplayedEffects(type);
            }
        }
    }

    private void DisplayLibraryEffectsOfType(InteractionManager.InteractionTypes type)
    {
        foreach(EffectSelectUI ui in _activeEffectUIs)
        {
            Effect effect = ui.GetEffect();
            if (effect == null)
                return;

            if(effect.InteractionType == type)
            {
                ui.gameObject.SetActive(true);
            } else
            {
                ui.gameObject.SetActive(false);
            }

        }
    }

    private void SelectInteractionTypeTab(InteractionManager.InteractionTypes type)
    {
        foreach (UIEffect ui in _tabEffects)
            ui.isActive = false;

        switch (type)
        {
            //I know this is gross, but it works for now
            default:
            case InteractionManager.InteractionTypes.Sound:
                if(0 < _tabEffects.Count)
                    _tabEffects[0].isActive = true;
                break;
            case InteractionManager.InteractionTypes.Animation:
                if (1 < _tabEffects.Count)
                    _tabEffects[1].isActive = true;
                break;
            case InteractionManager.InteractionTypes.Particle:
                if (2 < _tabEffects.Count)
                    _tabEffects[2].isActive = true;
                break;
            case InteractionManager.InteractionTypes.Feedback:
                if (3 < _tabEffects.Count)
                    _tabEffects[3].isActive = true;
                break;

        }
    }

    #endregion
}
