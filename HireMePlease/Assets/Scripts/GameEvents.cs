using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake(){
        current = this;
    }
    //Door Opening Event Action
    public event Action<int> onDoorwayTriggerEnter;
    public void DoorwayTriggerEnter(int id){
        if(onDoorwayTriggerEnter != null){
            onDoorwayTriggerEnter(id);
        }
    }
    //Door Closing Event Action
    public event Action<int> onDoorwayTriggerExit;
    public void DoorwayTriggerExit(int id){
        if(onDoorwayTriggerExit != null){
            onDoorwayTriggerExit(id);
        }
    }
}
