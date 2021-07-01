using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideSlot : MonoBehaviour, IDropHandler
{   
    //public GameObject MainLogic;
    public int slideID;
    public void OnDrop(PointerEventData eventData){
        if(eventData.pointerDrag != null){
            eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = true;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            if(slideID == eventData.pointerDrag.GetComponent<DragDrop>().slideID){
                Debug.Log("Correct Slide");
                eventData.pointerDrag.GetComponent<DragDrop>().isDraggable = false;
                this.transform.parent.GetComponent<PresentationTaskLogic>().correctSlides++;
            }
            else{
                Debug.Log("Wrong Slide");
            }
        }
    }
}
