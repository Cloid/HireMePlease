using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Task
{
    public int taskID = -1;
    public bool isActive;

    public string title;
    public string description;
    public float time;
    
    public TaskGoal goal;

    public void Complete(){
        isActive = false;
        Debug.Log(title + " was completed");
    }

    public void changeTaskType(int id){
        taskID = id;
        if(taskID == 0){
            Debug.Log("Coffee Task");
            title = "Coffee Run!";
            description = "Go get some coffee intern!";
        } else if (taskID == 1){
            Debug.Log("Some Task");

        } else if (taskID == 2){
            Debug.Log("Some Task2");

        }
        

    }

}
