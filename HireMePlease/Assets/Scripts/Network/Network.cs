using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Network : MonoBehaviourPunCallbacks
{
    public CameraFollow playerCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Spawn the player in along with their own camera
        playerCamera.target = PhotonNetwork.Instantiate("Player",
            new Vector3(
                0,
                0,
                0),
                Quaternion.identity).transform;
    }

}
