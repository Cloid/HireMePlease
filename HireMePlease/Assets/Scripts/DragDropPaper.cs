using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropPaper : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{   
    public bool droppedOnSlot = false;
    public bool isDraggable = true;
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    
    private void OnEnable() {
        //defaultPos = transform.position;
    }

    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        //defaultPos = transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData){
        Debug.Log("OnBeginDrag");
        if(isDraggable){
            //eventData.pointerDrag.GetComponent<DragDrop>().droppedOnSlot = false;
            //canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(isDraggable){
            Debug.Log("OnDrag");
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        if(isDraggable){
            Debug.Log("OnEndDrag");
            canvasGroup.blocksRaycasts = true;
        }
    }

    public void OnPointerDown(PointerEventData eventData){
        //throw new System.NotImplementedException();
        //Debug.Log("OnPointerDown");
    }

    public void OnDrop(PointerEventData eventData){
        //throw new System.NotImplementedException();

    }
}
