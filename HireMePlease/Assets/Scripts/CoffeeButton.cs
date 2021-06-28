using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CoffeeButton : MonoBehaviour, IPointerDownHandler
{
    public GameObject liquid;
    public GameObject CoffeeTask;
    public void OnPointerDown(PointerEventData eventData)
    {
        liquid.SetActive(true);
        CoffeeTask.GetComponent<CoffeeTaskScript>().IsTaskCompleted = true;
    }
}
