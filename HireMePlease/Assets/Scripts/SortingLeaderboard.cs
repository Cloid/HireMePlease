using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using Photon.Pun;
public class SortingLeaderboard : MonoBehaviour
{
    //References to leaderboard rankings  
    [SerializeField] private Text rank1;
    [SerializeField] private Text rank2;
    [SerializeField] private Text rank3;
    [SerializeField] private Text rank4;
    [SerializeField] private Text score1;
    [SerializeField] private Text score2;
    [SerializeField] private Text score3;
    [SerializeField] private Text score4;

    private GameObject[] goList;

    // Start is called before the first frame update
    void Start()
    {
        goList = GameObject.FindGameObjectsWithTag("Player");
        //Add Bonus Points
        for(int idx = 0; idx < goList.Length;idx++){
            Player currPlayer = goList[idx].GetComponent<Player>().GetComponent<Player>();
            currPlayer.addPts();
            currPlayer.photonView.RPC("SyncValues", Photon.Pun.RpcTarget.AllBuffered, currPlayer.taskDone, currPlayer.bonusPt);
        }

        var newList = goList.OrderBy(e => e.GetComponent<Player>().taskDone).ToList();
        
        for(int idx = 0; idx < newList.Count; idx++){
            Player currPlayer = newList[idx].GetComponent<Player>().GetComponent<Player>();
            if(currPlayer.taskDone == 0){
                newList.Add(newList[idx]);
                newList.Remove(newList[idx]);
            }
        }

        for(int idx = 0; idx < newList.Count; idx++){
            Player currPlayer = newList[idx].GetComponent<Player>().GetComponent<Player>();
            if(idx == 0){
                rank1.text = currPlayer.gameObject.GetPhotonView().Owner.NickName;
                score1.text = currPlayer.taskDone.ToString();
            } else if (idx == 1){
                rank2.text = currPlayer.gameObject.GetPhotonView().Owner.NickName;
                score2.text = currPlayer.taskDone.ToString();

            } else if (idx == 2){
                rank3.text = currPlayer.gameObject.GetPhotonView().Owner.NickName;
                score3.text = currPlayer.taskDone.ToString();
  
            } else if (idx == 3){
                rank4.text = currPlayer.gameObject.GetPhotonView().Owner.NickName;
                score4.text = currPlayer.taskDone.ToString();
            }
            //currPlayer.taskDone
            Debug.Log(currPlayer.taskDone);
        }
        

    }

    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
