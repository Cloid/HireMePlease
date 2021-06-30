using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MeetingEvent : MonoBehaviour
{
    public PhotonView photonView;
    private bool eventBool;
    // Start is called before the first frame update
    void Start()
    {
        if(photonView.IsMine){
            Invoke("triggerMeeting", 10);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerMeeting(){
        Debug.Log("Test");
    }
}
