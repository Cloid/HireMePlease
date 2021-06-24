using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPopup : MonoBehaviour {
	public GameObject task;
	public GameObject pressEPrompt;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerStay(Collider other) {
    	pressEPrompt.SetActive(true);
        if(other.CompareTag("Player")) {
        	if(Input.GetKey(KeyCode.E)) {
        		task.SetActive(true);
        	}
        }
    }

    private void OnTriggerExit(Collider other) {
    	if(other.CompareTag("Player")) {
    		pressEPrompt.SetActive(false);
    	}
    }

    public void closeTask() {
    	task.SetActive(false);
    }
}
