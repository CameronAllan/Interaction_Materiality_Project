using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarFillUI : MonoBehaviour
{
    [Header("UI Behaviour Vars")]
    [SerializeField] private bool _canOverfill;
    private float _fillVelocity;
    [SerializeField] private float _fillTime;
    [SerializeField] private float _fillSpeed;


    [Header("UI Parts")]
    [SerializeField] private RectTransform _barBkg;
    [SerializeField] private RectTransform _barFill;
    [SerializeField] private RectTransform _barFillShadow;

    //Floats from 0-1f;
    [SerializeField] private float _currentBarFill;
    [SerializeField] private float _barfillTarget;

    [SerializeField] private RectTransform _barOverfill;
    [SerializeField] private RectTransform _barOverfillShadow;
    [SerializeField] private float _currentOverfill;
    [SerializeField] private float _overfillTarget;
    [SerializeField] private int _loops;

    [SerializeField] private AudioSource _audio;

    private void Update()
    {
        if(_currentBarFill != _barfillTarget)
        {
            if(_currentBarFill > _barfillTarget)
            {
                DecreaseBarFill();

            } else
            {
                IncreaseBarFill();   
            }

        } else if (_canOverfill && _currentOverfill != _overfillTarget)
        {
            //Todo:
        }
    }

    public void UpdateBarFill(float fillAmount, float maxFill)
    {

        float barFill = 1f;
        barFill = fillAmount / maxFill;

        if (barFill > 1f)
            barFill = 1f;

        //TODO: math to overfill/loop overfill
        SetNewFillTarget(barFill);
    }

    private void SetNewFillTarget(float target)
    {
        float clamped = Mathf.Clamp(target, 0f, 1f);

        

        if(clamped < _currentBarFill)
        {
            //Set the bar to the value, then lerp the shadow 
            _fillSpeed = (_currentBarFill - target) / _fillTime;

            _barFill.sizeDelta = new Vector2(_barBkg.sizeDelta.x * clamped, _barFill.sizeDelta.y);
            _barfillTarget = clamped;

        } else if (clamped > _currentBarFill)
        {
            //set the shadow to the value, then lerp the fill
            _fillSpeed = (target - _currentBarFill) / _fillTime;

            _barFillShadow.sizeDelta = new Vector2(_barBkg.sizeDelta.x * clamped, _barFillShadow.sizeDelta.y);
            _barfillTarget = clamped;
        }
    }

    private void SetNewOverfillTarget(float target, int loops)
    {
        //TODO:
    }

    #region Helpers

    private void IncreaseBarFill()
    {
        //float newBarFill = Mathf.SmoothDamp(_currentBarFill, _barfillTarget, ref _fillVelocity, _fillTime);
        float newBarFill = Mathf.MoveTowards(_currentBarFill, _barfillTarget, _fillSpeed * Time.deltaTime);

        _barFill.sizeDelta = new Vector2(_barBkg.sizeDelta.x * newBarFill, _barFill.sizeDelta.y);
        _currentBarFill = newBarFill;

        if (_currentBarFill == _barfillTarget)
        {
            //play sound or anim trigger
        }
    }

    private void DecreaseBarFill()
    {
        //float newBarFill = Mathf.SmoothDamp(_currentBarFill, _barfillTarget, ref _fillVelocity, _fillTime);
        float newBarFill = Mathf.MoveTowards(_currentBarFill, _barfillTarget, _fillSpeed * Time.deltaTime);

        _barFillShadow.sizeDelta = new Vector2(_barBkg.sizeDelta.x * newBarFill, _barFillShadow.sizeDelta.y);
        _currentBarFill = newBarFill;

        if(_currentBarFill == _barfillTarget)
        {
            //play sound or anim trigger
        }
    }

    public float GetFillPercent()
    {
        return _barfillTarget;
    }

    public float GetAnimTime()
    {
        return _fillTime;
    }

    #endregion
}
