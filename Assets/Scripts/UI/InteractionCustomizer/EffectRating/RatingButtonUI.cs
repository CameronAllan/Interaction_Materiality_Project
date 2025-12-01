using UnityEngine;
using UnityEngine.UI;

public class RatingButtonUI : MonoBehaviour
{
    [SerializeField] private RatingUI _parent;
    [SerializeField] private int _rating;

    [Header("Presentation Vars")]
    [SerializeField] private TMPro.TextMeshProUGUI _text;
    [SerializeField] private Image _bkgImage;
    [SerializeField] private Color _selectedColour;

    public void PopulateButton()
    {
        _text.text = _rating.ToString();
    }

    public void SubmitRating()
    {
        if(_parent != null)
        {
            _parent.RateCurrentButton(this, _rating);
        }
    }

    public void MarkSelected()
    {
        _bkgImage.color = _selectedColour;
    }

    public void UnMark()
    {
        _bkgImage.color = Color.white;
    }

}
