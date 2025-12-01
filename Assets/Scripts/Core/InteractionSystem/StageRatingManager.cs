using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class StageRatingManager : Singleton<StageRatingManager>
{
    public InteractionTarget CurrentRatingTarget;

    [SerializeField] private int _targetIndex;
    [SerializeField] private List<InteractionTarget> _ratingTargets;

    [Header("Rating Presentation Vars")]
    [SerializeField] private Vector3 _enterPosition;
    [SerializeField] private Vector3 _displayPosition;
    [SerializeField] private Vector3 _exitPosition;

    public void StartButtonRating()
    {
        foreach(InteractionTarget t in _ratingTargets)
        {
            SimpleMover mover = t.gameObject.GetComponent<SimpleMover>();
            if (mover != null)
            {
                mover.SnapToPosition(_enterPosition);
            }
        }

        _targetIndex = 0;
        SetCurrentRatingTarget(_ratingTargets[_targetIndex]);
    }

    public void SetCurrentRatingTarget(InteractionTarget t)
    {
        if(CurrentRatingTarget != null)
        {
            SimpleMover m = CurrentRatingTarget.gameObject.GetComponent<SimpleMover>();
            if(m != null)
            {
                m.SetTargetPosition(_exitPosition);
            }
        }

        CurrentRatingTarget = t;

        SimpleMover mover = CurrentRatingTarget.gameObject.GetComponent<SimpleMover>();
        if (mover != null)
        {
            mover.SetTargetPosition(_displayPosition);
        }
    }

    public void NextRatingTarget()
    {
        _targetIndex++;
        if(_targetIndex < _ratingTargets.Count)
        {
            SetCurrentRatingTarget(_ratingTargets[_targetIndex]);
        } else
        {
            ResetRatingObjects();
            GameManager.Instance.EnterEditMode();
        }
    }

    public void ResetRatingObjects()
    {
        CurrentRatingTarget = null;
        foreach (InteractionTarget t in _ratingTargets)
        {
            SimpleMover mover = t.gameObject.GetComponent<SimpleMover>();
            if (mover != null)
            {
                mover.SnapToPosition(_enterPosition);
            }
        }
    }
}
