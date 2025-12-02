using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class StageRatingManager : Singleton<StageRatingManager>
{
    public InteractionTarget CurrentRatingTarget;

    [SerializeField] private int _targetIndex;
    [SerializeField] private List<InteractionTarget> _ratingTargets;

    [SerializeField] private Vector3 _twoDOffset;

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
                if(t.Form == InteractionTarget.InteractionForms.TwoD)
                {
                    mover.SnapToPosition(_enterPosition + _twoDOffset);
                } else
                {
                    mover.SnapToPosition(_enterPosition);
                }
                    
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
                if (t.Form == InteractionTarget.InteractionForms.TwoD)
                {
                    m.SnapToPosition(_exitPosition + _twoDOffset);
                }
                else
                {
                    m.SnapToPosition(_exitPosition);
                }
            }
        }

        CurrentRatingTarget = t;

        SimpleMover mover = CurrentRatingTarget.gameObject.GetComponent<SimpleMover>();
        if (mover != null)
        {
            if (t.Form == InteractionTarget.InteractionForms.TwoD)
            {
                mover.SnapToPosition(_displayPosition + _twoDOffset);
            }
            else
            {
                mover.SnapToPosition(_displayPosition);
            }
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
            UIManager.Instance.GetRatingUI().GoToBuildMode();
            //GameManager.Instance.EnterEditMode();
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
                if (t.Form == InteractionTarget.InteractionForms.TwoD)
                {
                    mover.SnapToPosition(_enterPosition + _twoDOffset);
                }
                else
                {
                    mover.SnapToPosition(_enterPosition);
                }
            }
        }
    }

    public List<InteractionTarget> GetRatingTargets()
    {
        return _ratingTargets;
    }
}
