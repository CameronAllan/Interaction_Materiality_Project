using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    bool beingDragged;
    public bool worldSpace;
    public bool interactable = true;
    public enum DraggableType
    {
        Building,
        Resource,
        UI
    }
    public DraggableType draggableType;
    //public DragPayload payload;

    public Transform holder = null;
    public int holderIndex;

    public Transform parentToReturnTo = null;
    public float maxDragDistance;

    public Transform onDragOverlayParent;
    //public Transform placeHolderParent = null;

    //private GameObject placeHolder = null;

    public Image draggableImage;

    //World Space Drag Vars
    private Vector3 offset;
    public float cameraDist;

    public event EventHandler DragStarted;
    public event EventHandler DragEnded;

    void Start()
    {
        if(holder == null)
        {
            holder = transform.parent;
        }

        if(holder != null)
        {
            holderIndex = this.transform.GetSiblingIndex();
        }

        beingDragged = false;
        //draggableImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (interactable)
        {
            
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (interactable & !beingDragged)
        {
            
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            Debug.Log("Starting Drag");
            parentToReturnTo = holder;

            if (onDragOverlayParent != null)
            {
                transform.SetParent(onDragOverlayParent);
            }
            else
            {
                transform.SetParent(holder);
            }

            this.transform.SetSiblingIndex(holderIndex);
            draggableImage.raycastTarget = false;

            if (worldSpace)
            {
                //Vector3 newPos = new Vector3(eventData.enterEventCamera.ScreenToWorldPoint(eventData.position).x, eventData.enterEventCamera.ScreenToWorldPoint(eventData.position).y, transform.position.z);
                cameraDist = gameObject.transform.position.z - Camera.main.transform.position.z;
                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDist));
                //Vector3 newPos = eventData.enterEventCamera.ScreenToWorldPoint(Input.mousePosition);
                //this.transform.position = new Vector3(newPos.x, newPos.y, -0.1f);
            }
            else
            {
                this.transform.position = eventData.position;
            }

            

            if (DragStarted != null)
                DragStarted.Invoke(this, new EventArgs());
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            if (worldSpace)
            {

                //Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector3 newPos = new Vector3(eventData.enterEventCamera.ScreenToWorldPoint(eventData.position).x, eventData.enterEventCamera.ScreenToWorldPoint(eventData.position).y, transform.position.z);
                //this.transform.position = new Vector3(newPos.x, newPos.y, -0.1f);

                cameraDist = gameObject.transform.position.z - Camera.main.transform.position.z;
                Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDist);
                transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;

                //Debug.Log("World Space Draaaaag" + newPosition);
            }
            else
            {

                this.transform.position = eventData.position;
                //Debug.Log("Screen Space Draaaaag" + eventData.position);
            }

            
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (interactable)
        {
            if (parentToReturnTo == null)
            {
                parentToReturnTo = holder;
            }

            this.transform.SetParent(parentToReturnTo);
            this.transform.position = parentToReturnTo.position;
            //this.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
            if (parentToReturnTo == holder)
            {
                this.transform.SetSiblingIndex(holderIndex);
            }

            draggableImage.raycastTarget = true;

            

            if (DragEnded != null)
                DragEnded.Invoke(this, new EventArgs());
            //Destroy(placeHolder);
        }
    }

    public void ReturnToParent()
    {
        if(parentToReturnTo != null)
        {
            this.transform.SetParent(parentToReturnTo);
            this.transform.position = parentToReturnTo.position;
            if (parentToReturnTo == holder)
            {
                this.transform.SetSiblingIndex(holderIndex);
            }
            draggableImage.raycastTarget = true;
        }
    }

    public void ReturnToHolder()
    {
        if(holder != null)
        {
            this.transform.SetParent(holder);
            this.transform.position = holder.position;
            this.transform.SetSiblingIndex(holderIndex);
            draggableImage.raycastTarget = true;
        }
    }

    public void Reset()
    {
        
    }
}
