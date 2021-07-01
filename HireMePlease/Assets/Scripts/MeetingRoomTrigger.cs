using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MeetingRoomTrigger : MonoBehaviour
{
    public int playerCount = 0;
    public int roomCount = 0;
    public bool callOnce = false;
    public GameObject meetingDoor;

    private void Start() {
        roomCount = PhotonNetwork.CurrentRoom.PlayerCount;
    }

    public void playerCheck(){
        if(roomCount != PhotonNetwork.CurrentRoom.PlayerCount){
            roomCount = PhotonNetwork.CurrentRoom.PlayerCount;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            playerCount++;
            other.GetComponent<Player>().bonusAdd();
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")){
            playerCount--;
            other.GetComponent<Player>().bonusDc();
        }
    }

}
