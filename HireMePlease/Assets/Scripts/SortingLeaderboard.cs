using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SortingLeaderboard : MonoBehaviour
{
    //References to leaderboard rankings
    [SerializeField] private GameObject rank1;
    [SerializeField] private GameObject rank2;
    [SerializeField] private GameObject rank3;
    [SerializeField] private GameObject rank4;

    private GameObject[] goList;

    // Start is called before the first frame update
    void Start()
    {
        goList = GameObject.FindGameObjectsWithTag("Player");
        //Add Bonus Points
        for(int idx = 0; idx < goList.Length;idx++){
            Player currPlayer = goList[idx].GetComponent<Player>().GetComponent<Player>();
            currPlayer.addPts();
            currPlayer.photonView.RPC("SyncValue", Photon.Pun.RpcTarget.AllBuffered, currPlayer.taskDone, currPlayer.bonusPt);
        }

        var newList = goList.OrderBy(e => e.GetComponent<Player>().taskDone).ToList();
        
        foreach(GameObject go in newList){
           int idx = go.GetComponent<Player>().taskDone;
           Debug.Log(idx);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
