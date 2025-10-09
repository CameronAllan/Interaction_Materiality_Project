using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteraction : InteractionTarget, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private List<InteractionChain> ButtonDownEffects;
    [SerializeField] private List<InteractionChain> ButtonUpEffects;

    private void OnButtonDown()
    {
        foreach (InteractionChain chain in ButtonDownEffects)
        {
            chain.Play();
        }
    }

    private void OnButtonDownCallback()
    {

    }

    private void OnButtonUp()
    {
        foreach (InteractionChain chain in ButtonUpEffects)
        {
            chain.Play();
        }
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
}
