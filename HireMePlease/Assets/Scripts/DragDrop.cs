using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{   
    public bool droppedOnSlot = false;
    public bool isDraggable = true;
    public int slideID;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 defaultPos;

    
    private void OnEnable() {
        this.droppedOnSlot = false;
        this.isDraggable = true;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        defaultPos = this.transform.position;
    }

    private void OnDisable() {
        transform.position = defaultPos;
    }

    public void OnBeginDrag(PointerEventData eventData){
        //Debug.Log("OnBeginDrag");
        if(isDraggable){
            eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = false;
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData){
        //Debug.Log("OnDrag");
        if(isDraggable){
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        if(isDraggable){
            //Debug.Log("OnEndDrag");
            if (!droppedOnSlot){
                transform.position = defaultPos;
            }
            canvasGroup.blocksRaycasts = true;
        }
        canvasGroup.alpha = 1f;
    }

    public void OnPointerDown(PointerEventData eventData){
        //throw new System.NotImplementedException();
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Right Clicked this Object");
            this.resetSlide();
        }
        
    }

    public void OnDrop(PointerEventData eventData){
        //throw new System.NotImplementedException();
    }

    public void resetSlide(){
        transform.position = defaultPos;
    }

}
