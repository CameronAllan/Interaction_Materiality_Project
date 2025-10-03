using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NumberScroll : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private bool playAudio = false;
    [SerializeField] private AudioSource _audio;

    [SerializeField] private int _targetValue;
    [SerializeField] private int _currentValue;

    [SerializeField] private float _targetValueFloat;
    [SerializeField] private float _currentValueFloat;

    [SerializeField] private float _speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_targetValueFloat != _currentValueFloat)
        {
            ScrollNumber();
        }
    }

    private void ScrollNumber()
    {
        if (playAudio)
        {
            if (_targetValue != _currentValue && !_audio.isPlaying)
                _audio.Play();
        }
        
        float d = _speed * Time.deltaTime;

        _currentValueFloat = Mathf.RoundToInt(Mathf.MoveTowards(_currentValueFloat, _targetValueFloat, d));
        _currentValue = Mathf.RoundToInt(_currentValueFloat);

        //Debug.Log("Scrolling numberscroll current to " + _currentValue);
        _text.text = _currentValue.ToString();

        if (playAudio)
        {
            if (_targetValue == _currentValue && _audio.isPlaying)
                _audio.Stop();
        }
    }

    public void SetTargetValue(int value, float scrollTime = 0f)
    {
        //Debug.Log("Setting numberscroll target to " + value);
        if (scrollTime != 0f)
        {
            if(scrollTime > 0 && value != _currentValue)
            {
                int dist = 0;
                if(value > _currentValue)
                {
                    dist = value - _currentValue;
                } else
                {
                    dist = _currentValue - value;
                }

                _speed = (dist / scrollTime) * 10f;
            }
        }

        _targetValue = value;
        _targetValueFloat = value;
    }

    public void SnapValue(int value)
    {
        _targetValue = value;
        _targetValueFloat = value;
        _currentValue = value;
        _currentValueFloat = value;

        _text.text = value.ToString();
    }

    public float GetScrollSpeed()
    {
        return _speed;
    }
}
