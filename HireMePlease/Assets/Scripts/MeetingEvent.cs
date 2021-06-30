using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MeetingEvent : MonoBehaviour
{
    public PhotonView photonView;
    private bool eventBool;
    private float eventChance = .45f;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if(photonView.IsMine){
            Invoke("triggerMeeting", 30);
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerMeeting(){
        Debug.Log("Test");
        if(Random.value > eventChance){

        }
    }
}
