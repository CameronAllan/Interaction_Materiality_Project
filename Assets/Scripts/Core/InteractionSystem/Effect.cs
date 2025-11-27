using System;
using System.Collections;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    //This is the base class for all of our different interaction effects
    public float CurrentTime;
    public InteractionManager.InteractionTypes InteractionType;

    public abstract void Play();

}
