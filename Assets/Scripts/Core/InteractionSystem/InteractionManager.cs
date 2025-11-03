using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    [Header("Interaction Selection Vars")]
    [SerializeField] private List<InteractionTarget> _targetGOs;
    [SerializeField] private List<Sprite> _interactionIcons;

    [Header("Current Interaction Vars")]
    [SerializeField] private InteractionTarget _target;
    [SerializeField] private int _interactionIndex;
    [SerializeField] private Transform _targetHolder;

    [Header("Effect Library")]
    [SerializeField] private Transform _effectPrefabHolder;
    public List<Effect> _allEffects;

    public enum InteractionTypes
    {
        Default,
        Animation,
        Sound,
        Particle,
        Feedback
    }


    private void Start()
    {
        //grab the first interaction target in our array for now
        _interactionIndex = 0;
        SetInteractionTarget(_interactionIndex);

        EffectTimelineUI.Instance.PopulateEffectLibrary(_allEffects);

    }

    #region Interaction Changes

    public void AddInteractionTrack()
    {
        _target.BuildEmptyInteractionTrack(InteractionTypes.Default);
    }


    #endregion

    #region

    

    #endregion

    #region Helpers

    public InteractionTarget GetInteractionTarget()
    {
        return _target;
    }

    public void NextInteractionTarget()
    {
        _interactionIndex++;
        if(_interactionIndex >= _targetGOs.Count) 
            _interactionIndex = 0;

        SetInteractionTarget(_interactionIndex);
    }

    public void PrevInteractionTarget()
    {
        _interactionIndex--;
        if (_interactionIndex < 0)
            _interactionIndex = _targetGOs.Count - 1;

        SetInteractionTarget (_interactionIndex);
    }

    public void SetInteractionTarget(int targetIndex)
    {
        if (targetIndex < 0 || targetIndex >= _targetGOs.Count)
            return;

        if(_target != null)
            _target.gameObject.SetActive(false);

        _target = _targetGOs[targetIndex];
        _interactionIndex = targetIndex;
        _target.gameObject.SetActive(true);

        EffectTimelineUI.Instance.DisplayInteractionTarget(_target);
    }

    public void SetInteractionTarget(InteractionTarget newTarget)
    {
        if (newTarget == null)
            return;

        if (_target != null)
            _target.gameObject.SetActive(false);

        _target = newTarget;
        _interactionIndex = _targetGOs.IndexOf(_target);
        _target.gameObject.SetActive(true);

        EffectTimelineUI.Instance.DisplayInteractionTarget(_target);
    }

    public Sprite GetInteractionIcon(InteractionTypes type)
    {
        return null;
    }

    #endregion
}
