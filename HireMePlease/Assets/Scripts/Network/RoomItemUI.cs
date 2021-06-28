using UnityEngine;
using UnityEngine.UI;

public class RoomItemUI : MonoBehaviour
{
    public LobbyNetworkManager LobbyNetworkParent;
    [SerializeField] private Text _roomName;

    public Photon.Realtime.RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(Photon.Realtime.RoomInfo roomInfo){
        RoomInfo = roomInfo;
        _roomName.text = roomInfo.Name;
    }
    public void SetName(string roomName){
        _roomName.text = roomName;
    }

    public void OnJoinPressed(){
        LobbyNetworkParent.JoinRoom(_roomName.text);
    }
}
