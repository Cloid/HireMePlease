using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;
using Photon.Pun;
public class Network : MonoBehaviourPunCallbacks
{
    public CameraFollow playerCamera;
    //public int currPlayerCount = 0;
    private GameObject playerCount;
    public int playerIndex = 0;
    public PhotonView photonView;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerCount = GameObject.Find("DontDestroy");
        NeverDestroy index = playerCount.GetComponent<NeverDestroy>();

        // Spawn the player in along with their own camera
        try
        {
            if (index.playerIndex == 1)
            {
                player = PhotonNetwork.Instantiate("Player",
                    new Vector3(
                        0,
                        0,
                        0),
                        Quaternion.identity);
            }
            else if (index.playerIndex == 2)
            {
                player = PhotonNetwork.Instantiate("Player2",
                               new Vector3(
                                   0,
                                   0,
                                   0),
                                   Quaternion.identity);
            }
            else if (index.playerIndex == 3)
            {
                player = PhotonNetwork.Instantiate("Player3",
               new Vector3(
                   0,
                   0,
                   0),
                   Quaternion.identity);
            }
            else if (index.playerIndex == 4)
            {
                player = PhotonNetwork.Instantiate("Player4",
               new Vector3(
                   0,
                   0,
                   0),
                   Quaternion.identity);
            }

            playerCamera.target = player.transform;

        }
        catch (Exception e)
        {
            Debug.LogError("No Players in Scene. Cannot Instantiate Player." + e);
        }
    }

}
