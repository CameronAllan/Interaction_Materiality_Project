using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class RandomAnimOffset : MonoBehaviour
{
    [SerializeField] private Animator _foundAnim;
    [SerializeField] private float _rolledFloat;

    private void Awake()
    {
        _foundAnim = GetComponent<Animator>();
        _rolledFloat = Random.Range(0f, 1f);


    }

    private void Start()
    {
        if (_foundAnim != null)
            _foundAnim.SetFloat("Offset", _rolledFloat);
    }


    private void OnEnable()
    {
        if (_foundAnim != null)
            _foundAnim.SetFloat("Offset", _rolledFloat);
    }
}
