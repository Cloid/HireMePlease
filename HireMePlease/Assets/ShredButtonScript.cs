using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShredButtonScript : MonoBehaviour, IPointerDownHandler
{   
    public GameObject paperShredPieces;
    public GameObject Spawner;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(transform.parent.GetComponent<ShredMachineScript>().currentPaper != null){
            Destroy(transform.parent.GetComponent<ShredMachineScript>().currentPaper);
            transform.parent.GetComponent<BoxCollider2D>().enabled = true;

            if(transform.parent.GetComponent<ShredMachineScript>().shreddedPapers < 4){
                Instantiate(paperShredPieces,
                            Random.insideUnitSphere * 100 + this.transform.position, 
                            Quaternion.identity).transform.SetParent(this.transform.parent);
            }
        }
    }
}
