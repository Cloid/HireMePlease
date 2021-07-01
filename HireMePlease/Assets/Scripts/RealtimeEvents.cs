using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RealtimeEvents : MonoBehaviour
{
    private float eventChance = .45f;
    private int eventsHappened = 0;
    [SerializeField] private GameObject meetingEventUI;
    [SerializeField] private GameObject meetingEventcoll;
    [SerializeField] private GameObject meetingDoor;

    public PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("eventTrigger", 30);
        photonView.GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void eventTrigger(){

        if(eventsHappened == 2){
            Debug.Log("Max events reached");
            return;
        }

        if(eventsHappened == 0 && eventChance <= 45){
            Debug.Log("Forced Event Triggered");
            photonView.RPC("eventAction", RpcTarget.AllBuffered);
        }

        else if(Random.value <= eventChance){
            Debug.Log("Event Triggered");
            photonView.RPC("eventAction", RpcTarget.AllBuffered);
        } else {
            eventChance += 5f;
            Invoke("eventTrigger", 10);
        }
    }

    [PunRPC]
    public void eventAction(){
            meetingEventUI.SetActive(true);
            meetingEventcoll.SetActive(true);
            eventsHappened++;
            meetingEventcoll.GetComponent<MeetingRoomTrigger>().playerCheck();
            GameEvents.current.DoorwayTriggerEnter(1);
            //meetingDoor.GetComponent<DoorController>().onMeetingDoorOpen(1);
    }

}
