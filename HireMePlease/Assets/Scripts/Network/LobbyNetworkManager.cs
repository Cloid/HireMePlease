using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class LobbyNetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private InputField _roomInput;
    [SerializeField] private InputField _username;
    [SerializeField] private RoomItemUI _roomUIPrefab;
    [SerializeField] private Transform _roomListParent;
    [SerializeField] private RoomItemUI _playerItemUIPrefab;
    [SerializeField] private Transform _playerListParent;

    [SerializeField] private Text _statusField;
    [SerializeField] private Text _usernameField;
    [SerializeField] private Button _leaveRoomButton;
    [SerializeField] private Button _startGameButton;

    [SerializeField] private GameObject Lobby;
    [SerializeField] private GameObject LobbyReady;
    
    [SerializeField ]private GameObject playerCount;
    [SerializeField]private GameObject p1holder;
    [SerializeField]private GameObject p2holder;
    [SerializeField]private GameObject p3holder;
    [SerializeField]private GameObject p4holder;
    [SerializeField]private Text Tp1holder;
    [SerializeField]private Text Tp2holder;
    [SerializeField]private Text Tp3holder;
    [SerializeField]private Text Tp4holder;

    public Text holder;

    public PhotonView photonView;
    public GameObject playerName;


    private List<RoomItemUI> _playerList = new List<RoomItemUI>();

    private List<RoomItemUI> _roomList = new List<RoomItemUI>();

    // Start is called before the first frame update
    void Start()
    {
        if(photonView==null){
            GetComponent<PhotonView>();
        }
        if(playerCount==null){
            playerCount = GameObject.Find("DontDestroy");
        }
        Initialize();
        Connect();
        
    }

    #region PhotonCallbacks

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master server");
        PhotonNetwork.JoinLobby();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log("Current Room Count: " + roomList.Count);
        //UpdateRoomList(roomList);
        foreach (RoomInfo info in roomList)
        {

            if (info.RemovedFromList)
            {
                int index = _roomList.FindIndex(x => x.RoomInfo.Name == info.Name);
                if(index != -1){
                    Destroy(_roomList[index].gameObject);
                    _roomList.RemoveAt(index);
                }
            }
            else
            {
                RoomItemUI newRoomItem = Instantiate(_roomUIPrefab);
                newRoomItem.LobbyNetworkParent = this;
                newRoomItem.SetRoomInfo(info);
                //newRoomItem.SetName(roomList[i].Name);
                newRoomItem.transform.SetParent(_roomListParent);
                _roomList.Add(newRoomItem);
            }


        }
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    public override void OnJoinedRoom()
    {
        _statusField.text = "Joined " + PhotonNetwork.CurrentRoom.Name;
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        _leaveRoomButton.interactable = true;

        Debug.Log("Current Players: "+ PhotonNetwork.CurrentRoom.PlayerCount);
        playerCount.GetComponent<NeverDestroy>().playerIndex = PhotonNetwork.CurrentRoom.PlayerCount;
        NeverDestroy index = playerCount.GetComponent<NeverDestroy>();

        if (PhotonNetwork.IsMasterClient)
        {
            _startGameButton.interactable = true;
        }
        else
        {
            Lobby.SetActive(false);
            LobbyReady.SetActive(true);
        }
        
        if (index.playerIndex == 1)
            {
                playerName = PhotonNetwork.Instantiate("P1 Name",
                    p1holder.transform.position,
                        Quaternion.identity);
                        holder = Tp1holder;
            }
            else if (index.playerIndex == 2)
            {
                Debug.Log("test");
                playerName = PhotonNetwork.Instantiate("P2 Name",
                               p2holder.transform.position,
                                   Quaternion.identity);
                    holder = Tp2holder;

            }
            else if (index.playerIndex == 3)
            {
               playerName = PhotonNetwork.Instantiate("P3 Name",
               p3holder.transform.position,
                   Quaternion.identity);
                    holder = Tp3holder;

            }
            else if (index.playerIndex == 4)
            {
               playerName = PhotonNetwork.Instantiate("P4 Name",
               p4holder.transform.position,
                   Quaternion.identity);
                holder = Tp4holder;

            }
            string help = playerName.GetPhotonView().Owner.NickName;
            Debug.Log(help);
            photonView.RPC("syncName",RpcTarget.AllBuffered, help, index.playerIndex);

        UpdatePlayerList();
    }



    public override void OnLeftRoom()
    {
        _statusField.text = "Lobby";
        Debug.Log("LeftRoom");
        _leaveRoomButton.interactable = false;
        _startGameButton.interactable = false;
        UpdatePlayerList();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player player)
    {
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Photon.Realtime.Player player)
    {
        UpdatePlayerList();
    }

    #endregion

    private void Initialize()
    {
        _leaveRoomButton.interactable = false;
    }

    private void Connect()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(0, 5000);
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void newName()
    {
        PhotonNetwork.NickName = _username.text;
        _usernameField.text = PhotonNetwork.NickName;
    }
    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        //Clear the current list of rooms
        for (int i = 0; i < _roomList.Count; i++)
        {
            Destroy(_roomList[i].gameObject);
        }
        _roomList.Clear();
        //Generate a new list with the updated info
        for (int i = 0; i < roomList.Count; i++)
        {
            //skip empty rooms
            Debug.Log("test");
            if(roomList[i].PlayerCount==0){ continue;}
            RoomItemUI newRoomItem = Instantiate(_roomUIPrefab);
            newRoomItem.LobbyNetworkParent = this;
            newRoomItem.SetName(roomList[i].Name);
            newRoomItem.transform.SetParent(_roomListParent);
            _roomList.Add(newRoomItem);
        }
    }

    private void UpdatePlayerList()
    {
        //Clear the current player list
        for (int i = 0; i < _playerList.Count; i++)
        {
            Destroy(_playerList[i].gameObject);
        }
        _playerList.Clear();

        if (PhotonNetwork.CurrentRoom == null) { return; }

        //Generate a new list of players
        foreach (KeyValuePair<int, Photon.Realtime.Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            RoomItemUI newPlayerItem = Instantiate(_playerItemUIPrefab);
            newPlayerItem.transform.SetParent(_playerListParent);
            newPlayerItem.SetName(player.Value.NickName);
            _playerList.Add(newPlayerItem);
        }
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(_roomInput.text) == false)
        {
            PhotonNetwork.CreateRoom(_roomInput.text, new RoomOptions() { MaxPlayers = 4 }, null);
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void OnStartGamePressed()
    {
        PhotonNetwork.LoadLevel("Stage_1");
    }

    [PunRPC]
    public void syncName(string playername, int index){
        Debug.Log("name: "+ playername);
        if(index == 1){
            Tp1holder.text = playername;
        } else if( index == 2){
            Tp2holder.text = playername;
        } else if (index ==3 ){
            Tp3holder.text = playername;
        } else if (index == 4){
            Tp4holder.text = playername;
        }
        //nameObject.text = playername;
        //for(int idx = 0; )
    }
}
