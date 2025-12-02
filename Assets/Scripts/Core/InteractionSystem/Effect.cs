using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    [Header("Display Vars")]
    public string EffectName;
    public Sprite EffectIcon;
    public Color EffectColor;

    [Header("Effect Vars")]
    //This is the base class for all of our different interaction effects
    public float CurrentTime;
    public InteractionManager.InteractionTypes InteractionType;
    public InteractionTarget.InteractionForms InteractionForm;

    public abstract void Play();

}
