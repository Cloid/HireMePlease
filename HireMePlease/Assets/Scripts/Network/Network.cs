using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System;

public class Network : MonoBehaviourPunCallbacks
{
    public CameraFollow playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Spawn the player in along with their own camera
        try{
            playerCamera.target = PhotonNetwork.Instantiate("Player",
                new Vector3(
                    0,
                    0,
                    0),
                    Quaternion.identity).transform;
        }
        catch(Exception e){
            Debug.LogError("No Players in Scene. Cannot Instantiate Player.");
        }
        
    }

}
