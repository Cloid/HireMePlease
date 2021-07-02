using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Task
{
    public int taskID = -1;
    public bool isActive;

    public string title;
    public string description;
    public float time;

    public GameObject currTaskTit;
    public GameObject currTaskDesc;
    
    public TaskGoal goal;

    public void Complete(){
        isActive = false;
        Debug.Log(title + " was completed");
    }

    public void changeTaskType(int id){
        taskID = id;
        if(taskID == 0){
            //Debug.Log("Coffee Task");
            title = "Coffee Run!";
            description = "Go get some coffee intern!";
        } else if (taskID == 1){
            //Debug.Log("Some Task");
            title = "Throw Trash";
            description = "Pick up trash and throw it away";
        } else if (taskID == 2){
            title = "Make Presentation";
            description = "Make a presentation";
        } else if (taskID == 3){
            title = "Shredder";
            description = "Shred paper!";
        } else if (taskID == 4){
            title = "Close Popups";
            description = "Close all Popups!";

            //Debug.Log("Some Task 2");

        }
        

    }

    public void changeTaskUI(){
        currTaskTit = GameObject.Find("CurrentTaskName");
        currTaskDesc = GameObject.Find("CurrentTaskDesc");
        Debug.Log(currTaskTit);
        Debug.Log(title);
        currTaskTit.GetComponent<Text>().text = title;
        currTaskDesc.GetComponent<Text>().text = description;
    }

}
