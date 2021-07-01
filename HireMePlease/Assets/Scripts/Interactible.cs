using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour
{
    [SerializeField] private GameObject _taskWindow;

    public void Use(bool isActive, GameObject player){
        if(player == null){return;}
        Player playerInstance =  player.GetComponent<Player>();
        if(playerInstance == null){return;}
        if(playerInstance.TaskList[playerInstance.taskDone].taskID == 0 && _taskWindow.name == "CoffeeTask"){
            _taskWindow.SetActive(isActive);
            _taskWindow.GetComponent<GetPlayer>().player = player;
        }
    }
}
