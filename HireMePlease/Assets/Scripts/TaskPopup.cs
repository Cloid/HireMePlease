 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskPopup : MonoBehaviour {
	//public GameObject task;
    public static TaskPopup Instance;
	public GameObject pressEPrompt;
    public Interactible CurrentInteractible;
    public GameObject CurrentPlayer;
    
    private void Awake(){
        Instance = this;
    }

    // Start is called before the first frame update
    // // private void OnTriggerStay(Collider other) {
    //     var nom = other.gameObject.GetComponent<Player>();
    // 	//pressEPrompt.SetActive(true);
    //     if(nom != null && nom.photonView.IsMine) {
    //         pressEPrompt.SetActive(true);
    //     	if(Input.GetKey(KeyCode.E)) {
    //             if(CurrentInteractible == null){ return;}
    //     		CurrentInteractible.Use(true);
    //     	}
    //     }
    // }

    private void Update() {
        //var nom = other.gameObject.GetComponent<Player>();
    	//pressEPrompt.SetActive(true);
        //if(photonView.IsMine) {
            //pressEPrompt.SetActive(true);
        	if(Input.GetKey(KeyCode.E)) {
                if(CurrentInteractible == null){ return;}
        		CurrentInteractible.Use(true, CurrentPlayer);
        	}
        //}
    }

    // private void OnTriggerExit(Collider other) {
    // 	if(other.CompareTag("Player")) {
    // 		pressEPrompt.SetActive(false);
    // 	}
    // }

}
