using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private EffectEntryUI _entry;
    public bool limitToSingle;
    public UIDraggable currentDraggable = null;
    public UIDraggable.DraggableType compatibleType;
    public bool interactable = true;

    public event EventHandler SelectionChanged;
    public event EventHandler SelectionRemoved;


    
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

            if (_entry != null)
            {
                _entry.SelectEntry();
            }
        }
        //parentUI.DisplayHexYields();


    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;

        
        UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
        if (d != null && d.draggableType == compatibleType)
        {
            Debug.Log(eventData.pointerDrag.name + " dragged off of " + gameObject.name);

            /*
            currentDraggable = null;
            Debug.Log("A Dropzone invoked selectionChanged");
            if (SelectionChanged != null)
                SelectionChanged.Invoke(this, new EventArgs());
            */

            if (_entry != null)
            {
                _entry.DeselectEntry();
            }
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerDrag.name + " dropped on " + gameObject.name);

        UIDraggable d = eventData.pointerDrag.GetComponent<UIDraggable>();
        if (d != null)
        {
            /*
            if (compatibleType == UIDraggable.DraggableType.UI)
            {
                if (currentDraggable != null && limitToSingle)
                {
                    currentDraggable.parentToReturnTo = d.holder;
                    currentDraggable.ReturnToParent();
                    currentDraggable = null;

                    if (SelectionChanged != null)
                        SelectionChanged.Invoke(this, new EventArgs());
                }
            }*/

            if (d.draggableType == compatibleType)
            {
                currentDraggable = d;
            }

            Debug.Log("A Dropzone invoked selectionChanged");
            if(SelectionChanged != null)
                SelectionChanged.Invoke(this, new EventArgs());
            
        }
    }

    //VERRRYY wip for now I know this is atrocious
    public void ClearDraggable()
    {
        currentDraggable = null;
    }
}
