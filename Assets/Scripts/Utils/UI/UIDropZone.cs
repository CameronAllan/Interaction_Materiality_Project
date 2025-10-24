using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool limitToSingle;
    public UIDraggable currentDraggable = null;
    public UIDraggable.DraggableType compatibleType;
    public bool interactable = true;

    public event EventHandler selectionChanged;
    public event EventHandler selectionRemoved;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag == null)
            return;

        UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
        if(d != null && d.draggableType == compatibleType)
        {
            Debug.Log(eventData.pointerDrag.name + " dragged over " + gameObject.name);
            
            //d.placeHolderParent = this.transform;
            //d.parentToReturnTo = this.transform;
        }
        //parentUI.DisplayHexYields();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        if (eventData.pointerDrag == null)
            return;


        UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
        if (d != null && (d.parentToReturnTo == this.transform || d == currentDraggable))
        {
            Debug.Log(eventData.pointerDrag.name + " dragged off of " + gameObject.name);

            currentDraggable = null;
            Debug.Log("A Dropzone invoked selectionChanged");
            if (selectionChanged != null)
                selectionChanged.Invoke(this, new EventArgs());

        } 
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

        UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
        if (d != null)
        {
            if (compatibleType == UIDraggable.DraggableType.UI)
            {
                if (currentDraggable != null && limitToSingle)
                {
                    currentDraggable.parentToReturnTo = d.holder;
                    currentDraggable.ReturnToParent();
                    currentDraggable = null;

                    if (selectionChanged != null)
                        selectionChanged.Invoke(this, new EventArgs());
                }
            }

            if (d.draggableType == compatibleType)
            {
                if (interactable && compatibleType == UIDraggable.DraggableType.UI)
                {
                    d.parentToReturnTo = this.transform;

                    if (limitToSingle)
                    {
                        currentDraggable = d;
                    }
                }
            }

            Debug.Log("A Dropzone invoked selectionChanged");
            if(selectionChanged != null)
                selectionChanged.Invoke(this, new EventArgs());
            
        }
    }

}
