using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class InteractionTarget : MonoBehaviour
{
    [SerializeField] private int _interactionInts;
    [SerializeField] private List<string> _interactionNames;


    //Okay this needs to tell the Interaction Manager what it is, what interactions it has by default, and where the user can add new ones
    [SerializeField] protected List<InteractionChain> DefaultEffects;

    [SerializeField] protected List<InteractionChain> AddedEffects;

    [Header("Animation Vars")]
    [SerializeField] private Transform _animRoot;

    public abstract void SetupInteraction(); 

    #region Helpers

    public abstract List<InteractionChain> GetDefaultInteractions();

    public abstract List<InteractionChain> BuildEmptyInteractionTrack(InteractionManager.InteractionTypes type);

    //public abstract List<InteractionChain> GetAllInteractions();



    public abstract void AddInteractionTrack(List<InteractionChain> chains);

    public abstract void RemoveInteractionTrack(List<InteractionChain> chains);

    public Transform GetAnimRoot()
    {
        return _animRoot;
    }

    public int GetInteractionSlotCount()
    {
        return _interactionInts;
    }

    public int GetInteractionDepth()
    {
        //This is INCREDIBLY janky I just need it to work for tmo's demo
        return AddedEffects.FirstOrDefault().GetSlotCount();
    }

    public InteractionChain TryGetAddedEffectByIndex(int index)
    {
        if(index < AddedEffects.Count)
        {
            return AddedEffects[index];
        } else
        {
            return null;
        }
    }

    public List<string> GetSlotNames()
    {
        return _interactionNames;
    }

    #endregion
}
