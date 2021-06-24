using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _roomInput;
    [SerializeField] private RoomItemUI _roomUIPrefab;
    [SerializeField] private Transform _roomListParent;
    private List<RoomItemUI> _roomList = new List<RoomItemUI>();
    // Start is called before the first frame update
    void Start()
    {
      Connect();  
    }

    #region PhotonCallbacks

    public override void OnConnectedToMaster(){
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        UpdateRoomList(roomList);
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

    #endregion

    
    private void Connect(){
        PhotonNetwork.NickName = "Player" + Random.Range(0,5000);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void UpdateRoomList(List<RoomInfo> roomList){
        //Clear the current list of rooms
        for(int i = 0; i<_roomList.Count;i++){
            Destroy(_roomList[i].gameObject);
        }
        _roomList.Clear();
        //Generate a new list with the updated info
        for(int i = 0; i< roomList.Count;i++){
            //skip empty rooms
            if(roomList[i].PlayerCount==0){ continue;}
            RoomItemUI newRoomItem = Instantiate(_roomUIPrefab);
            newRoomItem.LobbyNetworkParent = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.transform.SetParent(_roomListParent);
            _roomList.Add(newRoomItem);
        }
    }

    public void JoinRoom(string roomName){
        PhotonNetwork.JoinRoom(roomName);
    }

    public void CreateRoom(){
        if(string.IsNullOrEmpty(_roomInput.text) == false){
            PhotonNetwork.CreateRoom(_roomInput.text, new RoomOptions() { MaxPlayers = 4}, null);
        }
    }
}
