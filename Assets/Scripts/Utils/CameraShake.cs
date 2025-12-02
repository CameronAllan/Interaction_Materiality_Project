using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;

//Again, v. rough
public class CameraShake : Singleton<CameraShake>
{
    [SerializeField] private Transform _shakeHolder;

    [SerializeField] private Vector3 _setPosition;

    [Header("Screen Shake Vars")]
    [SerializeField] private bool _screenShaking;
    Coroutine currentShakeRoutine;
    [SerializeField] private float _shakeMagnitude;
    [SerializeField] private float _shakeFalloff;


    [Header("Zoom Bump Vars")]
    [SerializeField] private bool _bumpZooming;
    Coroutine currentBumpRoutine;
    [SerializeField] private float _bumpDist;
    [SerializeField] private float _bumpSpeed;

    public void Update()
    {
        if (_screenShaking)
        {
            if(_shakeMagnitude > 0)
            {
                _shakeHolder.localPosition = _setPosition + (UnityEngine.Random.insideUnitSphere * _shakeMagnitude);
                _shakeMagnitude -= Time.deltaTime * _shakeFalloff;
            } else
            {
                _shakeHolder.localPosition = _setPosition;
                _screenShaking = false;
            }
        }

        if (_bumpZooming)
        {
            if(_bumpDist > 0)
            {
                transform.position = new Vector3(0, 0, _bumpDist);
                _bumpDist -= Time.deltaTime * _bumpSpeed;

            } else
            {
                transform.position = new Vector3();
                _bumpZooming = false;
            }
        }
    }

    public void ScreenShake(float magnitude)
    {
        if (currentShakeRoutine != null)
            StopCoroutine(currentShakeRoutine);

        _shakeMagnitude = magnitude;

        _screenShaking = true;
        //currentShakeRoutine = StartCoroutine(ScreenShake());
    }

    public void BumpZoom(float dist)
    {
        if(currentBumpRoutine != null)
            StopCoroutine(currentBumpRoutine);

        _bumpDist = dist;

        _bumpZooming = true;
        //currentBumpRoutine = StartCoroutine(ZoomBump());
    }


    private IEnumerator ScreenShake()
    {
        float newMagnitude = _shakeMagnitude;

        while(newMagnitude < 0)
        {
            _shakeHolder.localPosition = _shakeHolder.localPosition + (UnityEngine.Random.insideUnitSphere * newMagnitude);
            newMagnitude -= Time.deltaTime * _shakeFalloff;

            yield return null;
        }

        _shakeHolder.localPosition = _setPosition;
        yield break;
    }

    private IEnumerator ZoomBump()
    {
        float newDist = _bumpDist;

        while(newDist < 0)
        {
            transform.position = new Vector3(0, 0, newDist);
            newDist -= Time.deltaTime * _bumpSpeed;

            yield return null;
        }

        transform.position = new Vector3(0, 0, 0);
        yield break;
    }


}
