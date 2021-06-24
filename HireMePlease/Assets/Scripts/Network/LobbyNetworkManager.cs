using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _roomInput;
    // Start is called before the first frame update
    void Start()
    {
      Connect();  
    }

    private void Connect(){
        PhotonNetwork.NickName = "Player" + Random.Range(0,5000);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        //base.OnJoinedRoom();
    }

    public void CreateRoom(){
        if(string.IsNullOrEmpty(_roomInput.text) == false){
            PhotonNetwork.CreateRoom(_roomInput.text, new RoomOptions() { MaxPlayers = 4}, null);
        }
    }
}
