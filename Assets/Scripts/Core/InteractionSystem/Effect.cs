using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    //This is the base class for all of our different interaction effects
    public float MinTime;
    public float MaxTime;

    public abstract void Play();

}
