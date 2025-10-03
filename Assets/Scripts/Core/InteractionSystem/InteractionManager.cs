using System;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : Singleton<InteractionManager>
{
    [Header("Interaction Selection Vars")]
    [SerializeField] private List<InteractionTarget> _targetPrefabs;

    [Header("Current Interaction Vars")]
    [SerializeField] private InteractionTarget _target;





    #region Helpers

    public void SetInteractionTarget(InteractionTarget newTarget)
    {

    }

    #endregion
}
