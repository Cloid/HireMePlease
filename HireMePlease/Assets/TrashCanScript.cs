using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    public GameObject trashCounter;
    public int trashCount;

    private void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("ENTERED TRIGGER");
        if(other.CompareTag("Trash")){
            trashCount++;
            trashCounter.GetComponent<UnityEngine.UI.Text>().text = trashCount.ToString();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        //Debug.Log("EXITED TRIGGER");
        if(other.CompareTag("Trash")){
            trashCount--;
            trashCounter.GetComponent<UnityEngine.UI.Text>().text = trashCount.ToString();
        }
    }
}
