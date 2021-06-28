using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoffeeButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject liquid;

    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        liquid.GetComponent<ParticleSystem>().Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log(this.gameObject.name + " Was Clicked.");
        liquid.GetComponent<ParticleSystem>().Stop();
    }
}
