using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class RatingUI : MonoBehaviour
{
    [SerializeField] private UIEffect _ratingButtonsHolder;

    [Header("Current Rating Vars")]
    [SerializeField] private int _currentRating = 0;
    [SerializeField] private List<RatingButtonUI> _ratingUIButtons;
    [SerializeField] private List<InteractionTarget> _ratingButtons;

    private Dictionary<InteractionTarget, int> _currentRatings;

    public InteractionTarget Favourite;

    [Header("Display Vars")]
    [SerializeField] private TextMeshProUGUI _enText;
    [SerializeField] private TextMeshProUGUI _frText;

    [SerializeField] private RectTransform _submitButton;


    public void DisplayUI()
    {
        _currentRatings = new Dictionary<InteractionTarget, int>();

        _ratingButtons = StageRatingManager.Instance.GetRatingTargets().ToList();

        foreach (InteractionTarget target in _ratingButtons)
        {
            _currentRatings.Add(target, 0);
        }

        foreach(RatingButtonUI ui in _ratingUIButtons)
        {
            ui.PopulateButton();
        }

        if (GameManager.Instance.French)
        {
            _enText.gameObject.SetActive(false);
            _frText.gameObject.SetActive(true);
        } else
        {
            _enText.gameObject.SetActive(true);
            _frText.gameObject.SetActive(false);
        }

        _ratingButtonsHolder.isActive = true;
        _submitButton.gameObject.SetActive(false);
    }

    public void RateCurrentButton(RatingButtonUI button, int rating)
    {
       
        foreach (RatingButtonUI ui in _ratingUIButtons)
        {
            ui.UnMark();
        }

        _currentRating = rating;

        button.MarkSelected();

        if(!_submitButton.gameObject.activeSelf)
            _submitButton.gameObject.SetActive(true);
    }

    public void SubmitButtonRating()
    {
        if (!_currentRatings.ContainsKey(StageRatingManager.Instance.CurrentRatingTarget))
            _currentRatings.Add(StageRatingManager.Instance.CurrentRatingTarget, _currentRating);

        _currentRatings[StageRatingManager.Instance.CurrentRatingTarget] = _currentRating;

        _submitButton.gameObject.SetActive(false);
        foreach (RatingButtonUI ui in _ratingUIButtons)
        {
            ui.UnMark();
        }

        StageRatingManager.Instance.NextRatingTarget();
    }

    public void GoToBuildMode()
    {
        int max = 0;
        InteractionTarget fave = null;

        foreach(KeyValuePair<InteractionTarget, int> entry in _currentRatings)
        {
            if(entry.Value > max)
            {
                fave = entry.Key;
                max = entry.Value;
            }
        }
        Favourite = fave;
        GameManager.Instance.EnterEditMode();
    }

    public void PackupUI()
    {

    }
}
