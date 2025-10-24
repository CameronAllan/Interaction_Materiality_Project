using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    [Header("Interaction Selection Vars")]
    [SerializeField] private List<InteractionTarget> _targetPrefabs;
    [SerializeField] private List<Sprite> _interactionIcons;

    [Header("Current Interaction Vars")]
    [SerializeField] private InteractionTarget _target;

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
        EffectTimelineUI.Instance.PopulateEffectLibrary(_allEffects);
        EffectTimelineUI.Instance.DisplayInteractionTarget(_target);
    }

    #region Interaction Changes

    public void AddInteractionTrack()
    {
        _target.BuildEmptyInteractionTrack(InteractionTypes.Default);
    }


    #endregion

    #region Helpers

    public InteractionTarget GetInteractionTarget()
    {
        return _target;
    }

    public void SetInteractionTarget(InteractionTarget newTarget)
    {

    }

    public Sprite GetInteractionIcon(InteractionTypes type)
    {
        return null;
    }

    #endregion
}
