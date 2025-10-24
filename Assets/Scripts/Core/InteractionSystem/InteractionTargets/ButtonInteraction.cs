using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteraction : InteractionTarget, IPointerDownHandler, IPointerUpHandler
{

    public override void SetupInteraction()
    {
        
    }

    private void OnButtonDown()
    {
        if (DefaultEffects[0] != null)
            DefaultEffects[0].Play();

        if (AddedEffects[0] != null)
            AddedEffects[0].Play();
    }

    private void OnButtonDownCallback()
    {

    }

    private void OnButtonUp()
    {
        if (DefaultEffects[1] != null)
            DefaultEffects[1].Play();

        if (AddedEffects[1] != null)
            AddedEffects[1].Play();
    }

    private void OnButtonUpCallback()
    {

    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnButtonDown();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        OnButtonUp();
    }

    #region Helpers

    public override List<InteractionChain> GetDefaultInteractions()
    {
        List<InteractionChain> ret = new List<InteractionChain>();

        //ret.AddRange(DefaultButtonDownEffects);
        //ret.AddRange(DefaultButtonUpEffects);

        return ret;
    }

    public override List<InteractionChain> BuildEmptyInteractionTrack(InteractionManager.InteractionTypes type)
    {
        return new List<InteractionChain>();
    }

    public override void AddInteractionTrack(List<InteractionChain> chains)
    {
        throw new NotImplementedException();
    }

    public override void RemoveInteractionTrack(List<InteractionChain> chains)
    {
        throw new NotImplementedException();
    }

    #endregion
}
